using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.UpdateProject
{
  public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
  {
    private readonly DevFreelanceDbContext _dbContext;
    public UpdateProjectCommandHandler(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
      var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

      project?.Update(request.Title, request.Description, request.TotalCost);

      await _dbContext.SaveChangesAsync();

      return Unit.Value;
    }
  }
}