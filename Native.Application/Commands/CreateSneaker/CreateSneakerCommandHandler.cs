using Native.Core.Entities;
using Native.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Native.Application.Commands.CreateSneaker;
public class CreateSneakerCommandHandler(ISneakerRepository sneakerRepository)
    : IRequestHandler<CreateSneakerCommand, int>
{
    private readonly ISneakerRepository _sneakerRepository = sneakerRepository;

    public async Task<int> Handle(CreateSneakerCommand request, CancellationToken cancellationToken)
    {
        var sneaker = new Sneaker(request.IdUser, request.Name, request.Brand, request.Price, request.Size, request.Year, request.Rate);

        await _sneakerRepository.AddAsync(sneaker);

        return sneaker.Id;
    }
}