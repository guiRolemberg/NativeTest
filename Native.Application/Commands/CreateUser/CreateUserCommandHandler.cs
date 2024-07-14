using Native.Core.Entities;
using Native.Core.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Native.Core.Repositories;

namespace Native.Application.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IAuthService _authService = authService;

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);

        var user = new User(request.Email, passwordHash);

        await _userRepository.AddAsync(user);

        return user.Id;
    }
}