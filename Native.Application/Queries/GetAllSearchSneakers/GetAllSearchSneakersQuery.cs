using MediatR;
using Native.Application.ViewModels;
using System.Collections.Generic;

namespace Native.Application.Queries.GetAllSearchSneakers;
public class GetAllSearchSneakersQuery(int idUser, string query) : IRequest<List<SneakerDetailsViewModel>>
{
    public int IdUser { get; private set; } = idUser;
    public string Query { get; private set; } = query;
}