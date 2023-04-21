using Core.Repositories;
using MediatR;

namespace Application.Commands.UpdateUser
{
  public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
      _userRepository = userRepository;
      _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
      var user = await _userRepository.GetUserDetailsAsync(request.Id);
      user?.Update(request.FullName, request.Email, request.BirthDate);
      await _unitOfWork.SaveChangesAsync();

      return Unit.Value;
    }
  }
}