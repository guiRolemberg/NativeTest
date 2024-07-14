using Native.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Native.Application.Commands.DeleteSneaker;
public class DeleteSneakerCommandHandler(ISneakerRepository sneakerRepository)
    : IRequestHandler<DeleteSneakerCommand, Unit>
{
    private readonly ISneakerRepository _sneakerRepository = sneakerRepository;

    public async Task<Unit> Handle(DeleteSneakerCommand request, CancellationToken cancellationToken)
    {
        var sneaker = await _sneakerRepository.GetByIdAsync(request.Id);

        await _sneakerRepository.DeleteAsync(sneaker);

        return Unit.Value;
    }
}
