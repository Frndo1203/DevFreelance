using MediatR;

namespace Application.Commands.DeleteProject
{
  public class DeleteProjectCommand : IRequest<Unit>
  {
    public DeleteProjectCommand(int id)
    {
      Id = id;
    }

    public int Id { get; set; }
  }
}