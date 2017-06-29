using GestionServicios.Commands;
using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.ViewModels.Base;

namespace GestionServicios.ViewModels
{
    internal class CreateServicioMasterViewModel : BaseViewModel
    {
        #region Fields

        private Servicio _servicio;

        #endregion

        #region Properties


        public Servicio Servicio
        {
            get { return _servicio; }
            set { _servicio = value; RaiseOnPropertyChanged(); }
        }

        public SaveServicioCommand SaveServicioCommand { get; set; }

        #endregion

        #region Constructor

        public CreateServicioMasterViewModel(MemoryContext context)
        {
            
        }

        #endregion
    }
}