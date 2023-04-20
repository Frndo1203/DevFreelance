using MediatR;

namespace Application.Commands.CreateUser
{
  public class CreateUserCommand : IRequest<int>
  {
    public string FullName { get; private set; }

    public String Email { get; private set; }

    public DateTime BirthDate { get; private set; }
  }
}