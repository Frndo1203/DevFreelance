using Application.ViewModels;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Queries.GetAllProjects
{
  public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
  {
    private readonly DevFreelanceDbContext _dbContext;
    public GetAllProjectsQueryHandler(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
      var projects = _dbContext.Projects;

      var projectsViewModel = await projects
        .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
        .ToListAsync();

      return projectsViewModel;
    }
  }
}