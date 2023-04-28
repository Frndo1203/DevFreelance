using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly DevFreelanceDbContext _dbContext;
    public UserRepository(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<User?> GetUserDetailsAsync(int id)
    {
      return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task AddAsync(User user)
    {
      await _dbContext.Users.AddAsync(user);
    }

    public async Task<int?> GetUserIdByEmailAsync(string email)
    {
      var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
      return user?.Id;
    }

    public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
      return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
    }
  }
}