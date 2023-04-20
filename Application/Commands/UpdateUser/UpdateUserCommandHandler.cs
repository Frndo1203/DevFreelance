using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.UpdateUser
{
  public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
  {
    private readonly DevFreelanceDbContext _dbContext;
    public UpdateUserCommandHandler(DevFreelanceDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
      var user = _dbContext.Users.SingleOrDefault(u => u.Id == request.Id);

      user.Update(request.FullName, request.Email, request.BirthDate);

      await _dbContext.SaveChangesAsync();

      return Unit.Value;
    }
  }
}