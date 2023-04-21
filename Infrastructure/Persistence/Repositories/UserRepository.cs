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
  }
}