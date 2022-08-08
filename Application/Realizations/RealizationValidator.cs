using Domain.Realizations;
using FluentValidation;

namespace Application.Realizations
{
    public class RealizationValidator : AbstractValidator<Realization>
    {
        public RealizationValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ShortDescription).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
        }
    }

    public class RealizationValidatorUpdate : AbstractValidator<Realization>
    {
        public RealizationValidatorUpdate()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ShortDescription).NotEmpty();
        }
    }
}
