using GestionServicios.Domain.Models;
using GestionServicios.ViewModels.Base;
using GestionServicios.ViewModels.Interfaces;

namespace GestionServicios.ViewModels
{
    internal class CreateLugarViewModel : BaseViewModel, IServicioModule
    {
        #region Fields

        private Lugar _selectedLugar;
        private Servicio _currentServicio;

        #endregion

        #region Properties

        public Servicio CurrentServicio
        {
            get { return _currentServicio; }
            set { _currentServicio = value; RaiseOnPropertyChanged(); }
        }

        public Lugar SelectedLugar
        {
            get { return _selectedLugar; }
            set { _selectedLugar = value; RaiseOnPropertyChanged(); }
        }

        #endregion

        public CreateLugarViewModel()
        {
            
        }
    }
}