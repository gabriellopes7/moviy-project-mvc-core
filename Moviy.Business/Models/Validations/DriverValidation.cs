using FluentValidation;

namespace Moviy.Business.Models.Validations
{
    public class DriverValidation : AbstractValidator<Driver>
    {
        public DriverValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(2)
                .WithMessage("O campo {PropertyName} precisa ter no mínimo {MinLength} caracteres")
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(x => x.Document)
                .Length(8)
                .WithMessage("O campo {PropertyName} precisa ter no mínimo {MinLength} caracteres")
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(x => x.DriverLicense)
                .Length(11)
                .WithMessage("O campo {PropertyName} precisa ter {MinLength} caracteres")
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(x => AgeValidation.IsOfAge(x.BirthDate))
                .Equal(true)
                .WithMessage("O motorista precisa ser maior de idade")
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido");


        }
    }
}
