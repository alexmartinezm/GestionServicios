using System.Collections.ObjectModel;
using GestionServicios.Domain.Models;

namespace GestionServicios.ViewModels.Interfaces
{
    internal interface IHasCallesList
    {
        ObservableCollection<Calle> CallesList { get; set; }
    }
}