using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
  public class User : BaseEntity
  {
    public User(string fullName, string email, DateTime birthDate)
    {
      FullName = fullName;
      Email = email;
      Active = true;
      BirthDate = birthDate;
      CreatedAt = DateTime.Now;

      Skills = new List<UserSkill>();
      OwnedProjects = new List<Project>();
      FreelanceProjects = new List<Project>();
    }
    public string FullName { get; private set; }

    public String Email { get; private set; }

    public DateTime BirthDate { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public bool Active { get; set; }

    public IList<UserSkill> Skills { get; private set; }

    public IList<Project> OwnedProjects { get; private set; }

    public IList<Project> FreelanceProjects { get; private set; }
  }
}