using Core.Entities;

namespace Core.Repositories
{
  public interface ISkillsRepository
  {
    Task<List<Skill>> GetAllAsync();
  }
}