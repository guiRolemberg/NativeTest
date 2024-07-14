using MediatR;
using Native.Application.ViewModels;
using Native.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Native.Application.Queries.GetAllSneakers;
public class GetAllSneakersQueryHandler(ISneakerRepository sneakerRepository) 
    : IRequestHandler<GetAllSneakersQuery, List<SneakerDetailsViewModel>>
{
    private readonly ISneakerRepository _sneakerRepository = sneakerRepository;

    public async Task<List<SneakerDetailsViewModel>> Handle(GetAllSneakersQuery request, CancellationToken cancellationToken)
    {
        var sneakers = await _sneakerRepository.GetAllAsync(request.IdUser);

        var sneakersViewModel = sneakers
            .Select(p => new SneakerDetailsViewModel(p.Id, p.Name, p.Brand, p.Price, p.Size, p.Year))
            .ToList();

        return sneakersViewModel;
    }
}