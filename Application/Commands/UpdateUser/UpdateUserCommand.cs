using MediatR;

namespace Application.Commands.UpdateUser
{
  public class UpdateUserCommand : IRequest<Unit>
  {
    public int Id { get; set; }
    public string FullName { get; private set; }

    public String Email { get; private set; }

    public DateTime BirthDate { get; private set; }
  }
}