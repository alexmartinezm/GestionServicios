using FluentValidation;
using GestionServicios.Domain.Models;
using GestionServicios.Resources;

namespace GestionServicios.Validators
{
    public class ServicioValidator : AbstractValidator<Servicio>
    {
        public ServicioValidator()
        {
            RuleFor(servicio => servicio.Fecha)
                .NotNull()
                .WithMessage(AppResources.FechaError);
            RuleFor(servicio => servicio.Descripcion)
                .NotNull()
                .WithMessage(AppResources.DescripcionError);
        }
    }
}