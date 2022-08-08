using Application.Core;
using Domain.Realizations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Realizations
{
    public class Details
    {
        public class Query : IRequest<Result<Realization>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<Realization>>
        {
            private readonly DataContext _context;


            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Realization>> Handle(Query request, CancellationToken cancellationToken)
            {
                var realisation = await _context.Realizations
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                return Result<Realization>.Success(realisation);
            }
        }
    }
}
