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

    modelBuilder.Entity<Project>()
        .HasOne(p => p.Client)
        .WithMany(c => c.OwnedProjects)
        .HasForeignKey(p => p.IdClient)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Project>()
      .HasOne(p => p.Freelancer)
      .WithMany(f => f.FreelanceProjects)
      .HasForeignKey(p => p.IdFreelancer)
      .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetEntryAssembly());
  }
}
