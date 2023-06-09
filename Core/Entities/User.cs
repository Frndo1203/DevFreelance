using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
  public class User : BaseEntity
  {
    public User(string fullName, string email, DateTime birthDate, string password, string role)
    {
      FullName = fullName;
      Password = password;
      Email = email;
      Role = role;
      Active = true;
      BirthDate = birthDate;
      CreatedAt = DateTime.Now;

      Skills = new List<UserSkill>();
      OwnedProjects = new List<Project>();
      FreelanceProjects = new List<Project>();
    }
    public string FullName { get; private set; }

    public string Password { get; private set; }

    public string Role { get; private set; }

    public String Email { get; private set; }

    public DateTime BirthDate { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public bool Active { get; set; }

    public List<UserSkill> Skills { get; private set; }

    public List<Project> OwnedProjects { get; private set; }

    public List<Project> FreelanceProjects { get; private set; }

    public List<ProjectComment> Comments { get; private set; }

    public void Update(string fullName, string password, string email, DateTime birthDate)
    {
      FullName = fullName;
      Password = password;
      Email = email;
      BirthDate = birthDate;
    }
  }
}