using GestionServicios.Commands;

namespace GestionServicios.ViewModels.Interfaces
{
    internal interface IHasCreateServicioCommand
    {
        CreateServicioCommand CreateServicioCommand { get; set; }
    }
}