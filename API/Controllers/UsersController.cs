using MediatR;
using Application.Commands.CreateUser;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.GetUser;
using System.Linq;
using Application.Commands.LoginUser;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
  [ApiController]
  [Authorize]
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

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
      var id = await _mediator.Send(command);

      return CreatedAtAction(nameof(GetById), new { id }, command);
    }

    // api/users/1/login
    [AllowAnonymous]
    [HttpPut("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
      var loginUserViewModel = await _mediator.Send(command);

      if (loginUserViewModel == null)
      {
        return BadRequest();
      }

      return Ok(loginUserViewModel);
    }
  }
}