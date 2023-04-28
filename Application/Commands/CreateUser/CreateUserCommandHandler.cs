using Core.Entities;
using Core.Repositories;
using Core.Services;
using MediatR;

namespace Application.Commands.CreateUser
{
  public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
  {
    private readonly IAuthService _authService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    public CreateUserCommandHandler(
      IUserRepository userRepository,
      IUnitOfWork unitOfWork,
      IAuthService authService)
    {
      _userRepository = userRepository;
      _unitOfWork = unitOfWork;
      _authService = authService;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      var userId = await _userRepository.GetUserIdByEmailAsync(request.Email);
      if (userId is not null)
      {
        return (int)userId;
      }

      var passwordHash = _authService.ComputeSha256Hash(request.Password);

      var user = new User(
        request.FullName,
        request.Email,
        request.BirthDate,
        passwordHash,
        request.Role
        );

      await _userRepository.AddAsync(user);
      await _unitOfWork.SaveChangesAsync();

      return user.Id;
    }
  }
}