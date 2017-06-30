using GestionServicios.Domain.Models;
using GestionServicios.ViewModels.Base;
using GestionServicios.ViewModels.Interfaces;
using GestionServicios.Views;

namespace GestionServicios.ViewModels
{
    internal class CreateServicioViewModel : BaseViewModel, IServicioModule
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

        public CreateServicioView CreateServicioView { get; set; }

        #endregion
    }
}