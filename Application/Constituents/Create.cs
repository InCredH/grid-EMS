using Domain;
using MediatR;
using Persistence;

namespace Application.Constituents
{
    public class Create
    {
        public class Command : IRequest
        {
            public Constituent Constituent { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Constituents.Add(request.Constituent);
                await _context.SaveChangesAsync();
            }
        }
    }
}