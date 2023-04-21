using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  public class SkillsRepository : ISkillsRepository
  {
    private readonly DevFreelanceDbContext _dbContext;
    public SkillsRepository(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<List<Skill>> GetAllAsync()
    {
      return await _dbContext.Skills.ToListAsync();
    }
  }
}