using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Auth
{
  public class AuthService : IAuthService
  {
    private readonly IConfiguration _configuration;
    public AuthService(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public string ComputeSha256Hash(string password)
    {
      using (SHA256 sha256Hash = SHA256.Create())
      {
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

        StringBuilder builder = new StringBuilder();
        foreach (var hash in bytes)
        {
          builder.Append(hash.ToString("x2"));
        }

        return builder.ToString();
      }
    }

    public string GenerateJwtToken(string email, string role)
    {
      var key = _configuration["Jwt:Key"];
      var issuer = _configuration["Jwt:Issuer"];
      var audience = _configuration["Jwt:audience"];

      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var claims = new List<Claim>
      {
        new Claim("userName", email),
        new Claim(ClaimTypes.Role, role)
      };

      var token = new JwtSecurityToken(
        issuer: issuer,
        audience: audience,
        expires: DateTime.Now.AddHours(8),
        signingCredentials: credentials,
        claims: claims);

      var tokenHandler = new JwtSecurityTokenHandler();

      return tokenHandler.WriteToken(token);
    }
  }
}