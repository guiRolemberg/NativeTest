using Native.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Native.Application.Commands.UpdateSneaker;
public class UpdateSneakerCommandHandler(ISneakerRepository sneakerRepository)
    : IRequestHandler<UpdateSneakerCommand, Unit>
{
    private readonly ISneakerRepository _sneakerRepository = sneakerRepository;

    public async Task<Unit> Handle(UpdateSneakerCommand request, CancellationToken cancellationToken)
    {
        var sneaker = await _sneakerRepository.GetByIdAsync(request.Id);

        sneaker.Update(request.Name, request.Brand, request.Price, request.Size, request.Year, request.Rate);

        await _sneakerRepository.UpdateAsync(sneaker);

        return Unit.Value;
    }
}