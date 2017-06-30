using System.Collections.ObjectModel;
using GestionServicios.Domain.Models;

namespace GestionServicios.ViewModels.Interfaces
{
    internal interface IShowServicios
    {
        ObservableCollection<Servicio> ServiciosList { get; set; }
        Servicio SelectedServicio { get; set; }
    }
}