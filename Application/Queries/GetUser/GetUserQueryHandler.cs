using Application.ViewModels;
using Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetUser
{
  public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDetailsViewModel>
  {
    private readonly IUserRepository _userRepository;
    public GetUserQueryHandler(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }
    public async Task<UserDetailsViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
      var user = await _userRepository.GetUserDetailsAsync(request.Id);

      return new UserDetailsViewModel(
        user.FullName,
        user.Email,
        user.BirthDate
      );
    }
  }
}