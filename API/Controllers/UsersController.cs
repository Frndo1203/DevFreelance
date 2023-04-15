using API.Models;
using Application.InputModels;
using Application.Services.Interfaces;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/users")]
  public class UsersController : ControllerBase
  {
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var user = _userService.GetById(id);

      return Ok(user);
    }

    [HttpPost]
    public IActionResult Post([FromBody] NewUserInputModel inputModel)
    {
      var id = _userService.Create(inputModel);

      return CreatedAtAction(nameof(GetById), new { id }, inputModel);
    }

    // api/users/1/login
    [HttpPut("{id}/login")]
    public IActionResult Login(int id, [FromBody] UpdateUserInputModel inputModel)
    {
      _userService.Update(inputModel);

      return NoContent();
    }
  }
}