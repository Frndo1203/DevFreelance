using Application.ViewModels;
using Core.Repositories;
using MediatR;

namespace Application.Queries.GetProjectById
{
  public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
  {
    private readonly IProjectRepository _projectRepository;
    public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
    {
      _projectRepository = projectRepository;
    }
    public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
      var project = await _projectRepository.GetByIdAsync(request.Id);

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