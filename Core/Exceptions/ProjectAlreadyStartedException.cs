using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Exceptions
{
  public class ProjectAlreadyStartedException : Exception
  {
    public ProjectAlreadyStartedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public ProjectAlreadyStartedException(string? message = "Project already in Started Status") : base(message)
    {
    }

    public ProjectAlreadyStartedException() : base()
    {
    }
  }
}