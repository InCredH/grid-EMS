using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Constituents
{
    public class Details
    {
        public class Query : IRequest<Constituent>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Constituent>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Constituent> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Constituents.FindAsync(request.Id);
            }
        }
    }
}