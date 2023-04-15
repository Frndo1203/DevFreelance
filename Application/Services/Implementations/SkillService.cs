using Application.Services.Interfaces;
using Application.ViewModels;
using Infrastructure.Persistence;

namespace Application.Services.Implementations
{
  public class SkillService : ISkillService
  {
    private readonly DevFreelanceDbContext _dbContext;
    public SkillService(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public List<SkillViewModel> GetAll()
    {
      var skill = _dbContext.Skills;

      return skill
        .Select(s => new SkillViewModel(s.Id, s.Description))
        .ToList();
    }
  }
}