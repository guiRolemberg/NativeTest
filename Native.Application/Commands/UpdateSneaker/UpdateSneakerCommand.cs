using MediatR;

namespace Native.Application.Commands.UpdateSneaker;
public class UpdateSneakerCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public int Size { get; set; }
    public int Year { get; set; }
    public int Rate { get; set; }
}