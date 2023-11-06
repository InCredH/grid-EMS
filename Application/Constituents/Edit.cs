using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Constituents
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Constituent Constituent { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var constituent = await _context.Constituents.FindAsync(request.Constituent.Id);
                
                _mapper.Map(request.Constituent, constituent);

                await _context.SaveChangesAsync();
            }
        }
    }
}