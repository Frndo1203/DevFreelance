using Application.Services.Interfaces;
using Application.ViewModels;
using Core.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementations
{
  public class ProjectService : IProjectService
  {
    private readonly DevFreelanceDbContext _dbContext;
    public ProjectService(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public List<ProjectViewModel> GetAll(string? query)
    {
      var projects = _dbContext.Projects;

      var projectsViewModel = projects
        .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
        .ToList();

      return projectsViewModel;
    }

    public ProjectDetailsViewModel GetById(int id)
    {
      var project = _dbContext.Projects
                    .Include(p => p.Client)
                    .Include(p => p.Freelancer)
                    .SingleOrDefault(p => p.Id == id);

      if (project == null)
      {
        return null;
      }

      return new ProjectDetailsViewModel(
        project.Id,
        project.Title,
        project.Description,
        project.TotalCost,
        project.StartedAt,
        project.FinishedAt,
        project.Client.FullName,
        project.Freelancer.FullName
      );
    }
  }
}