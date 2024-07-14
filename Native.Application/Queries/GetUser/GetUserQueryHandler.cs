using Native.Application.ViewModels;
using Native.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Native.Application.Queries.GetUser;
public class GetUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, UserViewModel>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        return user is null ? null : new UserViewModel(user.Email);
    }
}