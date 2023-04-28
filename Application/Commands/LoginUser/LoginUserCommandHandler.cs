using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModels;
using Core.Repositories;
using Core.Services;
using MediatR;

namespace Application.Commands.LoginUser
{
  public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
  {
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;
    public LoginUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
      _userRepository = userRepository;
      _authService = authService;
    }
    public async Task<LoginUserViewModel?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
      var passwordHash = _authService.ComputeSha256Hash(request.Password);
      var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

      if (user == null)
      {
        return null;
      }

      var token = _authService.GenerateJwtToken(user.Email, user.Role);
      return new LoginUserViewModel(user.Email, token);
    }
  }
}