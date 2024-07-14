using Native.Application.Commands.CreateUser;
using Native.Application.Commands.LoginUser;
using Native.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Native.API.Controllers;

[Route("api/users")]
[Authorize]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    // api/users/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _mediator.Send(new GetUserQuery(id));

        return user is null ? NotFound() : Ok(user);
    }

    // api/users
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, command);
    }

    // api/users/login
    [HttpPut("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var loginUserviewModel = await _mediator.Send(command);

        return loginUserviewModel is null ? BadRequest() : Ok(loginUserviewModel);
    }
}