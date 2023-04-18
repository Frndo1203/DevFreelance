using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DevFreelanceDbContext : DbContext
{
  public DevFreelanceDbContext(DbContextOptions<DevFreelanceDbContext> options) : base(options) { }

  public DbSet<Project> Projects { get; set; }

  public DbSet<User> Users { get; set; }

  public DbSet<Skill> Skills { get; set; }

  public DbSet<UserSkill> UserSkill { get; set; }

  public DbSet<ProjectComment> Comments { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetEntryAssembly());
  }
}
