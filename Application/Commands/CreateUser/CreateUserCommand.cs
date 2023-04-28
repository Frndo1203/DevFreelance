using MediatR;

namespace Application.Commands.CreateUser
{
  public class CreateUserCommand : IRequest<int>
  {
    public string FullName { get; set; }

    public string Password { get; set; }

    public string Role { get; set; }

    public String Email { get; set; }

    public DateTime BirthDate { get; set; }
  }
}