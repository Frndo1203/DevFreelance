using Application.ViewModels;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetUser
{
  public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDetailsViewModel>
  {
    private readonly DevFreelanceDbContext _dbContext;
    public GetUserQueryHandler(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<UserDetailsViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
      var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

      return new UserDetailsViewModel(
        user.FullName,
        user.Email,
        user.BirthDate
      );
    }
  }
}