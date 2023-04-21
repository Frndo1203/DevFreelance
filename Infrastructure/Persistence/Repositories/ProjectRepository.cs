using Core.Repositories;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
  private readonly DevFreelanceDbContext _dbContext;
  public ProjectRepository(DevFreelanceDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<List<Project>> GetAllAsync()
  {
    return await _dbContext.Projects.ToListAsync();
  }

  public async Task<Project?> GetByIdAsync(int id)
  {
    return await _dbContext
      .Projects
      .Include(p => p.Client)
      .Include(p => p.Freelancer)
      .SingleOrDefaultAsync(p => p.Id == id);
  }

  public async Task AddAsync(Project project)
  {
    await _dbContext.Projects.AddAsync(project);
  }

  public async Task AddCommentAsync(ProjectComment projectComment)
  {
    await _dbContext.Comments.AddAsync(projectComment);
  }
}
