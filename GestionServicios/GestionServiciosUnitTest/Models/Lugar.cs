using GestionServiciosUnitTest.Models.Base;

namespace GestionServiciosUnitTest.Models
{
    public class Lugar : EntityBase
    {
        public Calle Calle { get; set; }
        public int Numero { get; set; }
    }
}