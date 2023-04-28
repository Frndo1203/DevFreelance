using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModels;
using MediatR;

namespace Application.Commands.LoginUser
{
  public class LoginUserCommand : IRequest<LoginUserViewModel>
  {
    public string Email { get; set; }
    public string Password { get; set; }
  }
}