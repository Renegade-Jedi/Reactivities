using Application.Core;
using AutoMapper;
using Domain.Realizations;
using FluentValidation;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Realizations
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Realization Realization { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Realization).SetValidator(new RealizationValidatorUpdate());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var realization = await _context.Realizations.FindAsync(request.Realization.Id);
                if (realization == null) return null;
                
                realization.Title = request.Realization.Title ?? realization.Title;
                realization.Description = request.Realization.Description ?? realization.Description;
                realization.ShortDescription = request.Realization.ShortDescription ?? realization.ShortDescription;
                realization.Date = request.Realization?.Date ?? realization.Date;
                realization.Location = request.Realization?.Location ?? realization.Location;
              
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update Realization");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }

}
