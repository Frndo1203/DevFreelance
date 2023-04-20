using Application.ViewModels;

namespace Application.Services.Interfaces
{
  public interface IUserService
  {
    UserDetailsViewModel GetById(int id);
  }
}