using Native.Application.Commands.UpdateSneaker;
using FluentValidation;

namespace Native.Application.Validators;
public class UpdateSneakerCommandValidator : AbstractValidator<UpdateSneakerCommand>
{
    public UpdateSneakerCommandValidator()
    {
        RuleFor(p => p.Name)
            .MaximumLength(255)
            .WithMessage("Maximum length for Name is 255 characters.");

        RuleFor(p => p.Brand)
            .MaximumLength(30)
            .WithMessage("Maximum length for Brand is 30 characters.");

        RuleFor(p => p.Rate)
            .InclusiveBetween(1, 4)
            .WithMessage("Rate must be in a range between 1 and 4.");
    }
}