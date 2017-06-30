using GestionServicios.Commands;
using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Repository.Factories;
using GestionServicios.ViewModels.Base;
using GestionServicios.ViewModels.Interfaces;

namespace GestionServicios.ViewModels
{
    internal class CreateServicioMasterViewModel : BaseViewModel, IServicioModule, IHasSaveServicioCommand
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

        public SaveServicioCommand SaveServicioCommand { get; set; }

        public CreateServicioViewModel ServicioViewModel { get; set; }
        public CreateLugarViewModel LugarViewModel { get; set; }

        #endregion

        #region Constructor

        public CreateServicioMasterViewModel(MemoryContext context, Servicio selectedServicio = null)
        {
            InitViewModels();
            SaveServicioCommand = new SaveServicioCommand(context);
            CurrentServicio = selectedServicio ?? GenericFactory<Servicio>.Create();
            ServicioViewModel.CurrentServicio = CurrentServicio;
        }

        private void InitViewModels()
        {
            ServicioViewModel = new CreateServicioViewModel();
            LugarViewModel = new CreateLugarViewModel();
        }

        #endregion
    }
}