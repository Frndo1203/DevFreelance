using Application.ViewModels;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetProjectById
{
  public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
  {
    private readonly DevFreelanceDbContext _dbContext;
    public GetProjectByIdQueryHandler(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
      var project = await _dbContext.Projects
                        .Include(p => p.Client)
                        .Include(p => p.Freelancer)
                        .SingleOrDefaultAsync(p => p.Id == request.Id);

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