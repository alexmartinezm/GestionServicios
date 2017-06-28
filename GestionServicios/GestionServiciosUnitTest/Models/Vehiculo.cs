using GestionServiciosUnitTest.Models.Base;

namespace GestionServiciosUnitTest.Models
{
    public class Vehiculo : EntityBase
    {
        public string Matricula { get; set; }
        public Persona Propietario { get; set; }
    }
}