using Native.Application.ViewModels;
using MediatR;

namespace Native.Application.Commands.LoginUser;
public class LoginUserCommand : IRequest<LoginUserViewModel>
{
    public string Email { get; set; }
    public string Password { get; set; }
}