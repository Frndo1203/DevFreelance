using Application.InputModels;
using Application.Services.Interfaces;
using Application.ViewModels;
using Core.Entities;
using Infrastructure.Persistence;

namespace Application.Services.Implementations
{
  public class ProjectService : IProjectService
  {
    private readonly DevFreelanceDbContext _dbContext;
    public ProjectService(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public int Create(NewProjectInputModel inputModel)
    {
      var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient,
                                inputModel.IdFreelancer, inputModel.TotalCost);
      _dbContext.Projects.Add(project);

      return project.Id;
    }

    public void CreateComment(CreateCommentInputModel inputModel)
    {
      var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
      _dbContext.Comments.Add(comment);
    }

    public void Delete(int id)
    {
      var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

      project.Cancel();
    }

    public void Finish(int id)
    {
      var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

      project.Finish();
    }

    public List<ProjectViewModel> GetAll(string query)
    {
      var projects = _dbContext.Projects;

      var projectsViewModel = projects
        .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
        .ToList();

      return projectsViewModel;
    }

    public ProjectDetailsViewModel GetById(int id)
    {
      var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

      return new ProjectDetailsViewModel(
        project.Id,
        project.Title,
        project.Description,
        project.TotalCost,
        project.StartedAt,
        project.FinishedAt
      );
    }

    public void Start(int id)
    {
      var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

      project.Start();
    }

    public void Update(UpdateProjectInputModel inputModel)
    {
      var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

      project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
    }
  }
}