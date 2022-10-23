using FluentValidation;

namespace Moviy.Business.Models.Validations
{
    public class BusValidation : AbstractValidator<Bus>
    {
        public BusValidation()
        {
            RuleFor(x => x.BusNumber)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(x => x.LicensePlate)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(7)
                .WithMessage("O campo {PropertyName} precisa ter {Length} caracteres");
        }
    }
}
