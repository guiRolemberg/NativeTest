using Native.Application.ViewModels;
using Native.Core.Repositories;
using Native.Core.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Native.Application.Commands.LoginUser;
public class LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
    : IRequestHandler<LoginUserCommand, LoginUserViewModel>
{
    private readonly IAuthService _authService = authService;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        // Use the same algorithm to create the password hash
        var passwordHash = _authService.ComputeSha256Hash(request.Password);

        // Search for a User who has my email and password in hash format
        var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

        // If it doesn't exist, login error
        if (user is null) return null;

        // If it exists, generate the token using the user data
        var token = _authService.GenerateJwtToken(user.Email, "collector");

        return new LoginUserViewModel(user.Email, token);
    }
}