using Native.Application.ViewModels;
using Native.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Native.Application.Queries.GetSneakerById;
public class GetSneakerByIdQueryHandler(ISneakerRepository sneakerRepository)
    : IRequestHandler<GetSneakerByIdQuery, SneakerDetailsViewModel>
{
    private readonly ISneakerRepository _sneakerRepository = sneakerRepository;

    public async Task<SneakerDetailsViewModel> Handle(GetSneakerByIdQuery request, CancellationToken cancellationToken)
    {
        var sneaker = await _sneakerRepository.GetDetailsByIdAsync(request.Id);

        if (sneaker is null) return null;

        var sneakerDetailsViewModel = new SneakerDetailsViewModel(
            sneaker.Id,
            sneaker.Name,
            sneaker.Brand,
            sneaker.Price,
            sneaker.Size,
            sneaker.Year
            );

        return sneakerDetailsViewModel;
    }
}