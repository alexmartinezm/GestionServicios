using GestionServicios.Commands;

namespace GestionServicios.ViewModels.Interfaces
{
    internal interface IHasSaveServicioCommand
    {
        SaveServicioCommand SaveServicioCommand { get; set; }
    }
}