using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.InputModels
{
  public class UpdateProjectInputModel
  {
    public int Id { get; set; }
    public String Title { get; set; }

    public string Description { get; set; }

    public decimal TotalCost { get; set; }
  }
}