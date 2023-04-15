using Core.Entities;
using Application.InputModels;
using Application.Services.Interfaces;
using Application.ViewModels;
using Infrastructure.Persistence;

namespace Application.Services.Implementations
{
  public class UserService : IUserService
  {
    private readonly DevFreelanceDbContext _dbContext;
    public UserService(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public int Create(NewUserInputModel inputModel)
    {
      var user = new User(
        inputModel.FullName,
        inputModel.Email,
        inputModel.BirthDate
        );
      _dbContext.Users.Add(user);

      return user.Id;
    }

    public UserDetailsViewModel GetById(int id)
    {
      var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

      return new UserDetailsViewModel(
        user.FullName,
        user.Email,
        user.BirthDate
      );
    }

    public void Update(UpdateUserInputModel inputModel)
    {
      var user = _dbContext.Users.SingleOrDefault(u => u.Id == inputModel.Id);

      user.Update(inputModel.FullName, inputModel.Email, inputModel.BirthDate);
    }
  }
}