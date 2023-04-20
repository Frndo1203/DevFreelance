using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.FinishProject
{
  public class FinishProjectCommand : IRequest<Unit>
  {
    public FinishProjectCommand(int id)
    {
      Id = id;
    }

    public int Id { get; set; }
  }
}