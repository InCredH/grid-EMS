using Domain;
using FluentValidation;

namespace Application.Constituents
{
    public class ConstituentValidator : AbstractValidator<Constituent>
    {
        public ConstituentValidator()
        {
            RuleFor(x => x.ConstituentName).NotEmpty();
        }
    }
}