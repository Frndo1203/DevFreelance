using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.FinishProject
{
  public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
  {
    private readonly DevFreelanceDbContext _dbContext;
    public FinishProjectCommandHandler(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
      var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

      project.Finish();
      await _dbContext.SaveChangesAsync();

      return Unit.Value;
    }
  }
}