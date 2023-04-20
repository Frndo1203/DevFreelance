using API.Models;
using MediatR;
using Application.Commands.CreateUser;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.UpdateUser;
using Application.Queries.GetUser;

namespace API.Controllers
{
  [Route("api/users")]
  public class UsersController : ControllerBase
  {
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var query = new GetUserQuery(id);
      var user = await _mediator.Send(query);

      return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
      var id = await _mediator.Send(command);

      return CreatedAtAction(nameof(GetById), new { id }, command);
    }

    // api/users/1/login
    [HttpPut("{id}/login")]
    public IActionResult Login(int id, [FromBody] UpdateUserCommand command)
    {
      _mediator.Send(command);

      return NoContent();
    }
  }
}