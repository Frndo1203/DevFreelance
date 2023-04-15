using Application.ViewModels;

namespace Application.Services.Interfaces
{
  public interface ISkillService
  {
    List<SkillViewModel> GetAll();
  }
}