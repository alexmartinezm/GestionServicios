using FluentValidation;
using GestionServicios.Domain.Models;
using GestionServicios.Resources;

namespace GestionServicios.Validators
{
    public class PersonaValidator : AbstractValidator<Persona>
    {
        public PersonaValidator()
        {
            RuleFor(persona => persona.Dni)
                .NotNull()
                .WithMessage(AppResources.TipError);
        }
    }
}