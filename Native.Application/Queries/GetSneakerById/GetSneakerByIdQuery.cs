using Native.Application.ViewModels;
using MediatR;

namespace Native.Application.Queries.GetSneakerById;
public class GetSneakerByIdQuery(int id) : IRequest<SneakerDetailsViewModel>
{
    public int Id { get; private set; } = id;
}