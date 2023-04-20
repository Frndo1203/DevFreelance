using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.DeleteProject
{
  public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
  {
    private readonly DevFreelanceDbContext _dbContext;
    public DeleteProjectCommandHandler(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
      var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

      project.Cancel();
      await _dbContext.SaveChangesAsync();

      return Unit.Value;
    }
  }
}