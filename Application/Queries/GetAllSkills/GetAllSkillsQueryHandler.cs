using Application.ViewModels;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetAllSkills
{
  public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
  {
    private readonly DevFreelanceDbContext _dbContext;
    public GetAllSkillsQueryHandler(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
      var skill = _dbContext.Skills;

      var skillList = await skill
                            .Select(s => new SkillViewModel(s.Id, s.Description))
                            .ToListAsync();

      return skillList;
    }

  }
}