using FluentValidation;
using GestionServicios.Domain.Models;
using GestionServicios.Resources;

namespace GestionServicios.Validators
{
    public class AgenteValidator : AbstractValidator<Agente>
    {
        public AgenteValidator()
        {
            RuleFor(agente => agente.Tip)
                .NotNull()
                .WithMessage(AppResources.TipError);
        }
    }
}