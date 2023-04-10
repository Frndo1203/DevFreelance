using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/users")]
  public class UsersController : ControllerBase
  {

    public UsersController(ExampleClass exampleClass)
    {

    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      return Ok();
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateUserModel createuserModel)
    {
      return CreatedAtAction(nameof(GetById), new { id = 1 }, createuserModel);
    }

    // api/users/1/login
    [HttpPut("{id}/login")]
    public IActionResult Login(int id, [FromBody] LoginModel login)
    {
      return NoContent();
    }
  }
}