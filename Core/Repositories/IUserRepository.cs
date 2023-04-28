using Core.Entities;

namespace Core.Repositories
{
  public interface IUserRepository
  {
    Task<User?> GetUserDetailsAsync(int id);
    Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    Task<int?> GetUserIdByEmailAsync(string email);
    Task AddAsync(User user);
  }
}