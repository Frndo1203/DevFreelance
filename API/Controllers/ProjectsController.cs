using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{

  // api/projects?query=net
  [HttpGet]
  public IActionResult Get(string query)
  {

    return Ok();
  }

  // api/projects/599
  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
    // return NotFound();
    return Ok();
  }

  [HttpPost]
  public IActionResult Post([FromBody] CreateProjectModel createProject)
  {
    // return BadRequest();
    return Ok();
  }
}
