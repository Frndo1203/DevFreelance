using System.Data;
using Application.Commands.UpdateProject;
using FluentValidation;

namespace Application.Validators
{
  public class UpdateProjectValidator : AbstractValidator<UpdateProjectCommand>
  {
    public UpdateProjectValidator()
    {
      RuleFor(p => p.Title)
        .MaximumLength(30)
        .WithMessage("Tamanho maximo de Titulo e de 30 caracteres");

      RuleFor(p => p.Description)
        .MaximumLength(255)
        .WithMessage("Tamanho maximo de Descricao é de 255 caracteres.");
    }
  }
}