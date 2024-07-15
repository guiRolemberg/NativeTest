using Native.Application.Commands.CreateSneaker;
using FluentValidation;

namespace Native.Application.Validators;
public class CreateSneakerCommandvalidator : AbstractValidator<CreateSneakerCommand>
{
    public CreateSneakerCommandvalidator()
    {
        RuleFor(p => p.IdUser)
            .NotEmpty()
            .WithMessage("IdUser is required");

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(p => p.Name)
            .MaximumLength(255)
            .WithMessage("Maximum length for Name field is 255 characters.");

        RuleFor(p => p.Brand)
            .NotEmpty()
            .WithMessage("Brand is required");

        RuleFor(p => p.Brand)
            .MaximumLength(30)
            .WithMessage("Maximum length for Brand field is 30 characters.");

        RuleFor(p => p.Price)
            .NotEmpty()
            .WithMessage("Price is required");

        RuleFor(p => p.Size)
            .NotEmpty()
            .WithMessage("Size is required");

        RuleFor(p => p.Year)
            .NotEmpty()
            .WithMessage("Year is required");

        RuleFor(p => p.Rate)
            .NotEmpty()
            .WithMessage("Rate is required");

        RuleFor(p => p.Rate)
            .InclusiveBetween(1, 4)
            .WithMessage("Rate field must be in a range between 1 and 4.");
    }
}
