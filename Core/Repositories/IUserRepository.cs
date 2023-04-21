using Core.Entities;

namespace Core.Repositories
{
  public interface IUserRepository
  {
    Task<User?> GetUserDetailsAsync(int id);
    Task AddAsync(User user);
  }
}