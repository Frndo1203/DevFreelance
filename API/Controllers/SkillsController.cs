using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Queries.GetAllSkills;

namespace API.Controllers
{
  [ApiController]
  [Route("api/skills")]
  public class SkillsController : ControllerBase
  {
    private readonly IMediator _mediator;
    public SkillsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var query = new GetAllSkillsQuery();
      var skills = await _mediator.Send(query);

      return Ok(skills);
    }
  }
}