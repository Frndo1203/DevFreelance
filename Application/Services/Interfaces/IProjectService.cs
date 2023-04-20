using Application.ViewModels;
using Application.InputModels;

namespace Application.Services.Interfaces
{
  public interface IProjectService
  {
    List<ProjectViewModel> GetAll(string query);
    ProjectDetailsViewModel GetById(int id);
  }
}