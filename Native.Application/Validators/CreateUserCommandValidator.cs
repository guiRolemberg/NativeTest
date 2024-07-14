using Native.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Native.Application.Validators;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Email)
            .EmailAddress()
            .WithMessage("E-mail invalid!");

        RuleFor(p => p.Password)
            .Must(ValidPassword)
            .WithMessage("Password must contain at least 8 characters, a number, an uppercase letter, a lowercase letter, and a special character");
    }

    public static bool ValidPassword(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

        return regex.IsMatch(password);
    }
}