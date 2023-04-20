using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.CreateComment
{
  public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
  {
    private readonly DevFreelanceDbContext _dbContext;
    public CreateCommentCommandHandler(DevFreelanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
      var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);
      await _dbContext.Comments.AddAsync(comment);
      await _dbContext.SaveChangesAsync();

      return Unit.Value;
    }
  }
}