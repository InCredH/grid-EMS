using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Constituents
{
    public class List
    {
        public class Query : IRequest<List<Constituent>> { }

        public class Handler : IRequestHandler<Query, List<Constituent>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Constituent>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Constituents.ToListAsync();
            }
        }
    }
}