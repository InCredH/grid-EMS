using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Constituents
{
    public class Details
    {
        public class Query : IRequest<Result<Constituent>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Constituent>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Constituent>> Handle(Query request, CancellationToken cancellationToken)
            {
                var constituent = await _context.Constituents.FindAsync(request.Id);

                return Result<Constituent>.Success(constituent);
            }
        }
    }
}