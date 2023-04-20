using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.CreateProject
{
  public class CreateProjectCommand : IRequest<int>
  {
    public String Title { get; set; }

    public string Description { get; set; }

    public int IdClient { get; set; }

    public int IdFreelancer { get; set; }

    public decimal TotalCost { get; set; }

  }
}