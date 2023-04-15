using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ViewModels
{
  public class ProjectViewModel
  {

    public ProjectViewModel(int id, string title, DateTime createdAt)
    {
      Id = id;
      Title = title;
      CreatedAt = createdAt;
    }

    public int Id { get; set; }

    public string Title { get; private set; }

    public DateTime CreatedAt { get; private set; }
  }
}