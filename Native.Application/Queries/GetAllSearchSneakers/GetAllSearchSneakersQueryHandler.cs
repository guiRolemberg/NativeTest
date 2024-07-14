using MediatR;
using Native.Application.ViewModels;
using Native.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Native.Application.Queries.GetAllSearchSneakers;

public class GetAllSearchSneakersQueryHandler(ISneakerRepository sneakerRepository)
    : IRequestHandler<GetAllSearchSneakersQuery, List<SneakerDetailsViewModel>>
{
    private readonly ISneakerRepository _sneakerRepository = sneakerRepository;

    public async Task<List<SneakerDetailsViewModel>> Handle(GetAllSearchSneakersQuery request, CancellationToken cancellationToken)
    {
        var sneakers = await _sneakerRepository.GetAllSearchAsync(request.IdUser, request.Query);

        var sneakersViewModel = sneakers
            .Select(p => new SneakerDetailsViewModel(p.Id, p.Name, p.Brand, p.Price, p.Size, p.Year))
            .ToList();

        return sneakersViewModel;
    }
}
