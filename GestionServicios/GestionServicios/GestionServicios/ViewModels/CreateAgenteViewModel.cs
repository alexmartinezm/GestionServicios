using GestionServicios.Domain.Models;
using GestionServicios.ViewModels.Base;
using GestionServicios.ViewModels.Interfaces;

namespace GestionServicios.ViewModels
{
    internal class CreateAgenteViewModel : BaseViewModel, IServicioModule
    {
        #region Fields

        private Servicio _currentServicio;

        #endregion

        #region Properties

        public Servicio CurrentServicio
        {
            get { return _currentServicio; }
            set { _currentServicio = value; RaiseOnPropertyChanged(); }
        }

        #endregion

        public CreateAgenteViewModel()
        {
            
        }
    }
}