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

    public UserDetailsViewModel GetById(int id)
    {
      var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

      return new UserDetailsViewModel(
        user.FullName,
        user.Email,
        user.BirthDate
      );
    }
  }
}