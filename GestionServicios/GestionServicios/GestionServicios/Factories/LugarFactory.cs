using GestionServicios.Domain.Models;
using GestionServicios.Repository.Factories;

namespace GestionServicios.Factories
{
    public class LugarFactory : GenericFactory<Lugar>
    {
        public override Lugar Create()
        {
            return new Lugar
            {
                Calle = new CalleFactory().Create()
            };
        }
    }
}