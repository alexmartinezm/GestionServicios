using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Domain.Models
{
    public class Vehiculo : EntityBase
    {
        public string Matricula { get; set; }
        public Persona Propietario { get; set; }
    }
}