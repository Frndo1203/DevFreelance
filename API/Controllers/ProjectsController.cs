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
    // filtrar, buscar todos, etc.
    return Ok();
  }

  // api/projects/599
  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
    // Search the object
    // return NotFound();
    return Ok();
  }

  // api/projects/
  [HttpPost]
  public IActionResult Post([FromBody] CreateProjectModel createProject)
  {
    // Register the project
    if (createProject.Title.Length > 50)
    {
      return BadRequest();
    }
    return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
  }

  [HttpPost("{id}/comments")]
  public IActionResult PostComment(int id, [FromBody] CreateCommentsModel createComment)
  {
    return NoContent();
  }

  // api/projects/2
  [HttpPut("{id}")]
  public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
  {
    // Update the project
    if (updateProject.Description.Length > 50)
    {
      return BadRequest();
    }

    return NoContent();
  }

  [HttpPut("{id}/start")]
  public IActionResult Start(int id)
  {
    return NoContent();
  }

  [HttpPut("{id}/finish")]
  public IActionResult Finish(int id)
  {
    return NoContent();
  }

  // api/projects/3
  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    return NoContent();
  }
}
