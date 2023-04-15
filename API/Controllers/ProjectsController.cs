using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.InputModels;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
  private readonly IProjectService _projectService;

  public ProjectsController(IProjectService projectService)
  {
    _projectService = projectService;
  }

  // api/projects?query=net
  [HttpGet]
  public IActionResult Get(string query)
  {
    var projects = _projectService.GetAll(query);

    return Ok(projects);
  }

  // api/projects/599
  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
    var project = _projectService.GetById(id);

    if (project == null)
    {
      return NotFound();
    }
    return Ok(project);
  }

  // api/projects/
  [HttpPost]
  public IActionResult Post([FromBody] NewProjectInputModel inputModel)
  {
    // Register the project
    if (inputModel.Title.Length > 50)
    {
      return BadRequest();
    }

    var id = _projectService.Create(inputModel);

    return CreatedAtAction(nameof(GetById), new { id }, inputModel);
  }

  [HttpPost("{id}/comments")]
  public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel inputModel)
  {
    _projectService.CreateComment(inputModel);

    return NoContent();
  }

  // api/projects/2
  [HttpPut("{id}")]
  public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
  {
    // Update the project
    if (inputModel.Description.Length > 50)
    {
      return BadRequest();
    }

    _projectService.Update(inputModel);

    return NoContent();
  }

  [HttpPut("{id}/start")]
  public IActionResult Start(int id)
  {
    _projectService.Start(id);

    return NoContent();
  }

  [HttpPut("{id}/finish")]
  public IActionResult Finish(int id)
  {
    _projectService.Finish(id);

    return NoContent();
  }

  // api/projects/3
  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    _projectService.Delete(id);

    return NoContent();
  }
}
