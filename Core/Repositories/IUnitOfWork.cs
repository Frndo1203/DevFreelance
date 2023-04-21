using System;
using System.Collections.Generic;
namespace Core.Repositories
{
  public interface IUnitOfWork
  {
    Task SaveChangesAsync();
  }
}