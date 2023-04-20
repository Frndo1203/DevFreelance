using Core.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.CreateUser
{
  public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
  {
    private readonly DevFreelanceDbContext _dbContext;
    public CreateUserCommandHandler(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      var user = new User(
        request.FullName,
        request.Email,
        request.BirthDate
        );

      await _dbContext.Users.AddAsync(user);
      await _dbContext.SaveChangesAsync();

      return user.Id;
    }
  }
}