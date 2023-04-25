
using Application.Commands.CreateComment;
using FluentValidation;

namespace Application.Validators
{
  public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
  {
    public CreateCommentValidator()
    {
        RuleFor(c => c.Content)
            .MaximumLength(255)
            .WithMessage("O comentário não pode ter mais de 255 caracteres.");
    }
  }
}