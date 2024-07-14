using Native.Application.ViewModels;
using MediatR;

namespace Native.Application.Queries.GetUser;
public class GetUserQuery(int id) : IRequest<UserViewModel>
{
    public int Id { get; private set; } = id;
}
