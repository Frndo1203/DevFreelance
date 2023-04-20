using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.CreateProject
{
  public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
  {
    private readonly DevFreelanceDbContext _dbContext;

    public CreateProjectCommandHandler(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
      var project = new Project(request.Title, request.Description, request.IdClient,
                                request.IdFreelancer, request.TotalCost);
      await _dbContext.Projects.AddAsync(project);
      await _dbContext.SaveChangesAsync();

      return project.Id;
    }
  }
}