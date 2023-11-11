using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Constituents
{
    public class List
    {
        public class Query : IRequest<Result<List<Constituent>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Constituent>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Constituent>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Constituent>>.Success(await _context.Constituents.ToListAsync(cancellationToken));
            }
        }
    }
}