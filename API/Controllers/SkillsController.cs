using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.ViewModels;

namespace API.Controllers
{
  [ApiController]
  [Route("api/skills")]
  public class SkillsController
  {
    private readonly ISkillService _skillService;
    public SkillsController(ISkillService skillService)
    {
      _skillService = skillService;
    }

    [HttpGet]
    public IActionResult Get(string query)
    {
      var skills = _skillService.GetAll();

      return Ok(skills);
    }

    private IActionResult Ok(List<SkillViewModel> skills)
    {
      throw new NotImplementedException();
    }
  }
}