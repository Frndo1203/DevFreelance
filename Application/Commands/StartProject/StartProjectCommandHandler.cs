using Core.Repositories;
using MediatR;

namespace Application.Commands.StartProject
{
  public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProjectRepository _projectRepository;
    public StartProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
      _projectRepository = projectRepository;
      _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
      var project = await _projectRepository.GetByIdAsync(request.Id);
      project?.Start();
      await _unitOfWork.SaveChangesAsync();

      return Unit.Value;
    }
  }
}