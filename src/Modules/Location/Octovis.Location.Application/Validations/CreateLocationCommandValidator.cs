using FluentValidation;
using Octovis.Location.Application.UseCases.Commands.CreateLocation;

namespace Octovis.Location.Application.Validations
{
    public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.Description)
                .MaximumLength(250);

            RuleFor(x => x.ParentId)
                .NotEqual(Guid.Empty);
        }
    }

}
