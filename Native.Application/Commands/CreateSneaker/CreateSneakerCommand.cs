using MediatR;

namespace Native.Application.Commands.CreateSneaker;
public class CreateSneakerCommand : IRequest<int>
{
    public int IdUser { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public int Size { get; set; }
    public int Year { get; set; }
    public int Rate { get; set; }
}