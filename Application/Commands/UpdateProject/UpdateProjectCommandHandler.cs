using Core.Repositories;
using MediatR;

namespace Application.Commands.UpdateProject
{
  public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProjectRepository _projectRepository;
    public UpdateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
      _projectRepository = projectRepository;
      _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
      var project = await _projectRepository.GetByIdAsync(request.Id);
      project?.Update(request.Title, request.Description, request.TotalCost);
      await _unitOfWork.SaveChangesAsync();

      return Unit.Value;
    }
  }
}