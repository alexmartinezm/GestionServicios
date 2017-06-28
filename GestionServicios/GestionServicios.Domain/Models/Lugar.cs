using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Domain.Models
{
    public class Lugar : BaseModel
    {
        public Calle Calle { get; set; }
        public int Numero { get; set; }
    }
}