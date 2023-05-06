using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Commands.CreateProject;
using Application.Commands.CreateComment;
using Application.Commands.DeleteProject;
using Application.Commands.FinishProject;
using Application.Commands.UpdateProject;
using Application.Queries.GetAllProjects;
using Application.Queries.GetProjectById;
using Microsoft.AspNetCore.Authorization;
using Application.Commands.StartProject;

namespace API.Controllers;

[ApiController]
[Authorize]
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
  [Authorize(Roles = "freelancer, client")]
  public async Task<IActionResult> Get(string? query)
  {
    var getAllProjectsQuery = new GetAllProjectsQuery(query);
    var projects = await _mediator.Send(getAllProjectsQuery);

    return Ok(projects);
  }

  // api/projects/599
  [HttpGet("{id}")]
  [Authorize(Roles = "freelancer, client")]
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
  [Authorize(Roles = "client")]
  public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
  {
    var id = await _mediator.Send(command);

    return CreatedAtAction(nameof(GetById), new { id }, command);
  }

  [HttpPost("{id}/comments")]
  [Authorize(Roles = "client, freelancer")]
  public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
  {
    await _mediator.Send(command);

    return NoContent();
  }

  // api/projects/2
  [HttpPut("{id}")]
  [Authorize(Roles = "client")]
  public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
  {
    await _mediator.Send(command);

    return NoContent();
  }

  [HttpPut("{id}/start")]
  [Authorize(Roles = "client")]
  public async Task<IActionResult> Start(int id)
  {
    var command = new StartProjectCommand(id);
    await _mediator.Send(command);

    return NoContent();
  }

  [HttpPut("{id}/finish")]
  [Authorize(Roles = "client")]
  public async Task<IActionResult> Finish(int id)
  {
    var command = new FinishProjectCommand
    {
      Id = id
    };

    await _mediator.Send(command);

    return NoContent();
  }

  // api/projects/3
  [HttpDelete("{id}")]
  [Authorize(Roles = "client")]
  public async Task<IActionResult> Delete(int id)
  {
    var command = new DeleteProjectCommand(id);

    await _mediator.Send(command);

    return NoContent();
  }
}
