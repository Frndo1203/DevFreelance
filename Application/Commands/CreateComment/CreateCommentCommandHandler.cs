using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Application.Commands.CreateComment
{
  public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProjectRepository _projectRepository;
    public CreateCommentCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
      _projectRepository = projectRepository;
      _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
      var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);
      await _projectRepository.AddCommentAsync(comment);
      await _unitOfWork.SaveChangesAsync();

      return Unit.Value;
    }
  }
}