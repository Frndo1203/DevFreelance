using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Application.Commands.CreateProject
{
  public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProjectRepository _projectRepository;

    public CreateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
      _projectRepository = projectRepository;
    }
    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
      var project = new Project(request.Title, request.Description, request.IdClient,
                                request.IdFreelancer, request.TotalCost);
      await _projectRepository.AddAsync(project);
      await _unitOfWork.SaveChangesAsync();

      return project.Id;
    }
  }
}