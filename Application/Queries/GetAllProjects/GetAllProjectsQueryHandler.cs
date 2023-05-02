using Application.ViewModels;
using Core.Repositories;
using MediatR;


namespace Application.Queries.GetAllProjects
{
  public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
  {
    private readonly IProjectRepository _projectRepository;
    public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
    {
      _projectRepository = projectRepository;
    }
    public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
      var projects = await _projectRepository.GetAllAsync();

      var projectsViewModel = projects
        .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
        .ToList();

      return projectsViewModel;
    }
  }
}