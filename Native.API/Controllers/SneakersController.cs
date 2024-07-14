using Native.Application.Commands.CreateSneaker;
using Native.Application.Commands.DeleteSneaker;
using Native.Application.Commands.UpdateSneaker;
using Native.Application.Queries.GetAllSneakers;
using Native.Application.Queries.GetSneakerById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Native.Application.Queries.GetAllSearchSneakers;

namespace Native.API.Controllers;

[Route("api/sneakers")]
public class SneakersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    // api/sneakers?idUser=2
    [HttpGet]
    [Authorize(Roles = "collector")]
    public async Task<IActionResult> Get([FromQuery] GetAllSneakersQuery query)
    {
        var sneakers = await _mediator.Send(query);

        return Ok(sneakers);
    }

    //api/sneakers/search?idUser=2?query="test"
    [HttpGet("search")]
    [Authorize(Roles = "collector")]
    public async Task<IActionResult> Search([FromQuery] GetAllSearchSneakersQuery query)
    {
        var sneakers = await _mediator.Send(query);

        return Ok(sneakers);
    }

    // api/sneakers/2
    [HttpGet("{id}")]
    [Authorize(Roles = "collector")]
    public async Task<IActionResult> GetById([FromQuery] GetSneakerByIdQuery query)
    {
        var sneaker = await _mediator.Send(query);

        return sneaker is null ? NotFound() : Ok(sneaker);
    }

    [HttpPost]
    [Authorize(Roles = "collector")]
    public async Task<IActionResult> Post([FromBody] CreateSneakerCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(Post), new { id }, command);
    }

    // api/sneakers/2
    [HttpPut("{id}")]
    [Authorize(Roles = "collector")]
    public async Task<IActionResult> Put([FromQuery] int id, [FromBody] UpdateSneakerCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    // api/sneakers/3
    [HttpDelete("{id}")]
    [Authorize(Roles = "collector")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        var command = new DeleteSneakerCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }
}