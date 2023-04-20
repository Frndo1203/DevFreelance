using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.StartProject
{
  public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
  {
    private readonly DevFreelanceDbContext _dbContext;
    public StartProjectCommandHandler(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
      var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

      project?.Start();

      await _dbContext.SaveChangesAsync();

      return Unit.Value;
    }
  }
}