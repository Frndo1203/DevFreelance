using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
  public class SkillConfigurations : IEntityTypeConfiguration<Skill>
  {
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
      builder
      .HasKey(p => p.Id);
    }
  }
}