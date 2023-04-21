using Core.Entities;

namespace Core.Repositories
{
  public interface IProjectRepository
  {
    Task<List<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(int id);
    Task AddAsync(Project project);
    Task AddCommentAsync(ProjectComment projectComment);
  }
}