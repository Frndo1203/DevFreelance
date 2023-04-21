using Core.Repositories;
using MediatR;

namespace Application.Commands.DeleteProject
{
  public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProjectRepository _projectRepository;
    public DeleteProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
      _projectRepository = projectRepository;
      _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
      var project = await _projectRepository.GetByIdAsync(request.Id);
      project?.Cancel();
      await _unitOfWork.SaveChangesAsync();

      return Unit.Value;
    }
  }
}