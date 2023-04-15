using Core.Entities;

namespace Infrastructure.Persistence;

public class DevFreelanceDbContext
{
  public DevFreelanceDbContext()
  {
    Projects = new List<Project>
    {
        new Project("Meu projeto ASPNET Core 1", "Projeto sobre Clean Arch 1", 1, 1, 10000),
        new Project("Meu projeto ASPNET Core 2", "Projeto sobre Clean Arch 2", 1, 1, 20000),
        new Project("Meu projeto ASPNET Core 3", "Projeto sobre Clean Arch 3", 1, 1, 30000)
    };

    Users = new List<User>
    {
        new User("Fernando Oliveira", "oliveirafer06@gmail.com", new DateTime(1999, 3, 12)),
        new User("Fernando Antonio", "duelzack@gmail.com", new DateTime(1999, 3, 12)),
        new User("Fernando Barbosa", "duelzackary@gmail.com", new DateTime(1999, 3, 12))
    };

    Skills = new List<Skill>
    {
        new Skill(".Net Core"),
        new Skill("C#"),
        new Skill("Microsservices")
    };

    Comments = new List<ProjectComment>();
  }

  public List<Project> Projects { get; set; }

  public List<User> Users { get; set; }

  public List<Skill> Skills { get; set; }

  public List<ProjectComment> Comments { get; set; }


}
