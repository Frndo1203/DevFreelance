using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Commands.CreateProject;
using Application.Commands.CreateComment;
using Application.Commands.DeleteProject;
using Application.Commands.FinishProject;
using Application.Commands.UpdateProject;
using Application.Queries.GetAllProjects;
using Application.Queries.GetProjectById;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
  private readonly IMediator _mediator;

  public ProjectsController(IMediator mediator)
  {
    _mediator = mediator;
  }

  // api/projects?query=net
  [HttpGet]
  public async Task<IActionResult> Get(string? query)
  {
    var getAllProjectsQuery = new GetAllProjectsQuery(query);
    var projects = await _mediator.Send(getAllProjectsQuery);

    return Ok(projects);
  }

  // api/projects/599
  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var query = new GetProjectByIdQuery(id);
    var project = await _mediator.Send(query);

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
  public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
  {
    await _mediator.Send(command);

    return NoContent();
  }

  // api/projects/2
  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
  {
    // Update the project
    if (command.Description.Length > 50)
    {
      return BadRequest();
    }

    await _mediator.Send(command);

    return NoContent();
  }

  [HttpPut("{id}/start")]
  public async Task<IActionResult> Start(int id)
  {
    var command = StartProjectCommand(id);
    await _mediator.Send(command);

    return NoContent();
  }

  private object StartProjectCommand(int id)
  {
    throw new NotImplementedException();
  }

  [HttpPut("{id}/finish")]
  public async Task<IActionResult> Finish(int id)
  {
    var command = new FinishProjectCommand(id);

    await _mediator.Send(command);

    return NoContent();
  }

  // api/projects/3
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    var command = new DeleteProjectCommand(id);

    await _mediator.Send(command);

    return NoContent();
  }
}
