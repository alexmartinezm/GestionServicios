using System.Collections.ObjectModel;
using GestionServicios.Domain.Models;
using GestionServicios.Repository.Factories;

namespace GestionServicios.Factories
{
    public class ServicioFactory : GenericFactory<Servicio>
    {
        public override Servicio Create()
        {
            return new Servicio()
            {
                Lugar = new LugarFactory().Create(),
                Agente = new AgenteFactory().Create(),
                Vehiculos = new ObservableCollection<Vehiculo>(),
                Personas = new ObservableCollection<Persona>()
            };
        }
    }
}