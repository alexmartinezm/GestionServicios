using System.Text.RegularExpressions;
using FluentValidation;
using GestionServicios.Domain.Models;
using GestionServicios.Resources;

namespace GestionServicios.Validators
{
    public class VehiculoValidator : AbstractValidator<Vehiculo>
    {
        public VehiculoValidator()
        {
            RuleFor(vehiculo => vehiculo.Matricula)
                .NotNull()
                .WithMessage(AppResources.MatriculaVaciaError);
            RuleFor(vehiculo => vehiculo.Matricula)
                .Must(ValidarMatricula)
                .WithMessage(AppResources.MatriculaFormatoError);
            RuleFor(vehiculo => vehiculo.Propietario)
                .NotNull()
                .WithMessage(AppResources.PropietarioError);
        }

        /// <summary>
        /// Comprueba que la matrícula introducida cumple con el formato
        /// NNNN-LLL (números-letras).
        /// </summary>
        /// <param name="matricula">Matrícula a comprobar</param>
        /// <returns>True si es correcta.</returns>
        private static bool ValidarMatricula(string matricula)
        {
            // Patrón que define el formato de la matrícula
            const string pattern = "^[0-9]{4}-[A-Za-z]{3}$";

            return matricula != null && Regex.IsMatch(matricula, pattern);
        }
    }
}