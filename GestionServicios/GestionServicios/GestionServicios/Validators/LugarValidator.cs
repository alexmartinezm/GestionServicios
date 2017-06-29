using FluentValidation;
using GestionServicios.Domain.Models;
using GestionServicios.Resources;

namespace GestionServicios.Validators
{
    public class LugarValidator : AbstractValidator<Lugar>
    {
        public LugarValidator()
        {
            RuleFor(lugar => lugar.Calle.Valor)
                .NotNull()
                .WithMessage(AppResources.CalleError);
            RuleFor(lugar => lugar.Numero)
                .NotNull()
                .WithMessage(AppResources.NumeroCalleError);
        }
    }
}