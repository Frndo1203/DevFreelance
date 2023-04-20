using API.Models;
using MediatR;
using Application.Commands.CreateUser;
using Application.Services.Interfaces;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.UpdateUser;

namespace API.Controllers
{
  [Route("api/users")]
  public class UsersController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly IUserService _userService;
    public UsersController(IUserService userService, IMediator mediator)
    {
      _userService = userService;
      _mediator = mediator;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var user = _userService.GetById(id);

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