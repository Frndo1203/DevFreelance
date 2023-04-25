using MediatR;

namespace Application.Commands.UpdateUser
{
  public class UpdateUserCommand : IRequest<Unit>
  {
    public int Id { get; set; }
    public string FullName { get; set; }

    public string Password { get; set; }

    public String Email { get; set; }

    public DateTime BirthDate { get; set; }
  }
}