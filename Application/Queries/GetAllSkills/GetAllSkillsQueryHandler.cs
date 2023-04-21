using Application.ViewModels;
using Core.Repositories;
using MediatR;

namespace Application.Queries.GetAllSkills
{
  public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
  {
    private readonly ISkillsRepository _skillsRepository;
    public GetAllSkillsQueryHandler(ISkillsRepository skillsRepository)
    {
      _skillsRepository = skillsRepository;
    }
    public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
      var skill = await _skillsRepository.GetAllAsync();

      var skillList = skill
                    .Select(s => new SkillViewModel(s.Id, s.Description))
                    .ToList();

      return skillList;
    }

  }
}