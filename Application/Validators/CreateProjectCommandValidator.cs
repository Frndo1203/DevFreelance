using Application.Commands.CreateProject;
using FluentValidation;

namespace Application.Validators
{
  public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
  {
    public CreateProjectCommandValidator()
    {
      RuleFor(p => p.Description)
          .MaximumLength(255)
          .WithMessage("Tamanho maximo de Descricao é de 255 caracteres.");

      RuleFor(p => p.Title)
          .MaximumLength(30)
          .WithMessage("Tamanho maximo de Titulo e de 30 caracteres");
    }
  }
}