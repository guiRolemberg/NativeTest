using MediatR;

namespace Native.Application.Commands.CreateUser;
public class CreateUserCommand : IRequest<int>
{
    public string Email { get; set; }
    public string Password { get; set; }
}