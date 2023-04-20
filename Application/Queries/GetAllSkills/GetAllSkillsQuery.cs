using Application.ViewModels;
using MediatR;

namespace Application.Queries.GetAllSkills
{
  public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
  {

  }
}