using Core.Repositories;
using MediatR;

namespace Application.Commands.FinishProject
{
  public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProjectRepository _projectRepository;
    public FinishProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
      _projectRepository = projectRepository;
      _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
      var project = await _projectRepository.GetByIdAsync(request.Id);
      project?.Finish();
      await _unitOfWork.SaveChangesAsync();

      return Unit.Value;
    }
  }
}