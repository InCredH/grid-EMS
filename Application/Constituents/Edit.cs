using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Constituents
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Constituent Constituent { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Constituent).SetValidator(new ConstituentValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var constituent = await _context.Constituents.FindAsync(request.Constituent.Id);
                
                if (constituent == null) return null;
                
                _mapper.Map(request.Constituent, constituent);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update constituent");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}