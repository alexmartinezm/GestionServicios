using GestionServicios.Domain.Models;

namespace GestionServicios.ViewModels.Interfaces
{
    internal interface IServicioModule
    {
        Servicio CurrentServicio { get; set; }
    }
}