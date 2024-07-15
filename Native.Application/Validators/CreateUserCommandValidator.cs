using Native.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Native.Application.Validators;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty()
            .WithMessage("Email is required");

        RuleFor(p => p.Email)
            .EmailAddress()
            .WithMessage("Email is not valid");

        RuleFor(p => p.Password)
            .NotEmpty()
            .WithMessage("Password is required");

        RuleFor(p => p.Password)
            .Must(ValidPassword)
            .WithMessage("Password must contain at least 8 characters, a number, an uppercase letter, a lowercase letter, and a special character");
    }

    private static bool ValidPassword(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

        return regex.IsMatch(password);
    }
}