using Native.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Native.Application.Queries.GetAllSneakers;
public class GetAllSneakersQuery(int idUser) : IRequest<List<SneakerDetailsViewModel>>
{
    public int IdUser { get; private set; } = idUser;
}