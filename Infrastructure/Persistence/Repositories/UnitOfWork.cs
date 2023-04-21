using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositories;

namespace Infrastructure.Persistence.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly DevFreelanceDbContext _dbContext;
    public UnitOfWork(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task SaveChangesAsync()
    {
      await _dbContext.SaveChangesAsync();
    }
  }
}