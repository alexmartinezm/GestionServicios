using GestionServicios.Domain.Models;
using GestionServicios.Repository.Factories;

namespace GestionServicios.Factories
{
    public class CalleFactory : GenericFactory<Calle>
    {
        public override Calle Create()
        {
            return new Calle()
            {
                Valor = string.Empty
            };
        }
    }
}