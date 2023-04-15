using Application.InputModels;
using Application.ViewModels;

namespace Application.Services.Interfaces
{
  public interface IUserService
  {
    UserDetailsViewModel GetById(int id);

    int Create(NewUserInputModel inputModel);

    void Update(UpdateUserInputModel inputModel);
  }
}