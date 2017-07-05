using GestionServicios.Domain.Models;
using GestionServicios.Repository.Factories;

namespace GestionServicios.Factories
{
    public class PersonaFactory : GenericFactory<Persona>
    {
        public override Persona Create()
        {
            return new Persona()
            {
                Dni = string.Empty
            };
        }
    }
}