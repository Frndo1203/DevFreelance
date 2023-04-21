using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Application.Commands.CreateUser
{
  public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
      _userRepository = userRepository;
      _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      var user = new User(
        request.FullName,
        request.Email,
        request.BirthDate
        );

      await _userRepository.AddAsync(user);
      await _unitOfWork.SaveChangesAsync();

      return user.Id;
    }
  }
}