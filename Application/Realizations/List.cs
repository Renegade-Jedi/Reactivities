using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain.Realizations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Realizations
{
    public class List
    {
        public class Query : IRequest<Result<List<Realization>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<Realization>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Realization>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Realization>>.Success(await _context.Realizations.ToListAsync(cancellationToken));
            }
        }
    }
}
