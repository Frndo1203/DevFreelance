using System.Text.RegularExpressions;
using Application.Commands.LoginUser;
using FluentValidation;

namespace Application.Validators
{
  public class UpdateUserValidator : AbstractValidator<LoginUserCommand>
  {
    public UpdateUserValidator()
    {
      RuleFor(p => p.Email)
        .EmailAddress()
        .WithMessage("E-mail não válido!");

      RuleFor(p => p.Password)
        .Must(ValidPassword)
        .WithMessage(@"Senha deve conter pelo menos 8 caracteres, um numero,
                      uma letra maiuscula, uma minuscula, e um caracter especial");
    }
    public bool ValidPassword(string password)
    {
      var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

      return regex.IsMatch(password);
    }
  }
}