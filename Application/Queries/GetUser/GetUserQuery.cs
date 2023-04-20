using Application.ViewModels;
using MediatR;

namespace Application.Queries.GetUser
{
  public class GetUserQuery : IRequest<UserDetailsViewModel>
  {
    public GetUserQuery(int id)
    {
      Id = id;
    }

    public int Id { get; private set; }
  }
}