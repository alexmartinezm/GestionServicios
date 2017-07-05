using GestionServicios.Domain.Models;
using GestionServicios.Repository.Factories;

namespace GestionServicios.Factories
{
    public class VehiculoFactory : GenericFactory<Vehiculo>
    {
        public override Vehiculo Create()
        {
            return new Vehiculo
            {
                Matricula = string.Empty,
                Propietario = new PersonaFactory().Create()
            };
        }
    }
}