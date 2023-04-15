using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.InputModels
{
  public class NewUserInputModel
  {
    public string FullName { get; private set; }

    public String Email { get; private set; }

    public DateTime BirthDate { get; private set; }
  }
}