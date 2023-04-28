using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
  public interface IAuthService
  {
    string GenerateJwtToken(string email, string role);
    string ComputeSha256Hash(string password);
  }
}