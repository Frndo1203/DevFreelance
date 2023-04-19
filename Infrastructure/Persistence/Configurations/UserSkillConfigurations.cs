using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
  public class UserSkillConfigurations : IEntityTypeConfiguration<UserSkill>
  {
    public void Configure(EntityTypeBuilder<UserSkill> builder)
    {
      builder
     .HasKey(p => p.Id);
    }
  }
}