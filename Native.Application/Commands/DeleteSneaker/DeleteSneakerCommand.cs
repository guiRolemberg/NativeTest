using MediatR;

namespace Native.Application.Commands.DeleteSneaker;
public class DeleteSneakerCommand(int id) : IRequest<Unit>
{
    public int Id { get; private set; } = id;
}