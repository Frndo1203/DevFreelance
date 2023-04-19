using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.InputModels;
using MediatR;
using Application.Commands.CreateProject;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
  private readonly IProjectService _projectService;
  private readonly IMediator _mediator;

  public ProjectsController(IProjectService projectService, IMediator mediator)
  {
    _projectService = projectService;
    _mediator = mediator;
  }

  // api/projects?query=net
  [HttpGet]
  public IActionResult Get(string? query)
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
  public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
  {
    // Register the project
    if (command.Title.Length > 50)
    {
      return BadRequest();
    }

    var id = await _mediator.Send(command);

    return CreatedAtAction(nameof(GetById), new { id }, command);
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
