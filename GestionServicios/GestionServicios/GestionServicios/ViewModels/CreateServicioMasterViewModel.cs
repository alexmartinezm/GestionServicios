using System.Collections.ObjectModel;
using GestionServicios.Commands;
using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Mocks.Mocks;
using GestionServicios.Repository.Factories;
using GestionServicios.ViewModels.Base;
using GestionServicios.ViewModels.Interfaces;

namespace GestionServicios.ViewModels
{
    internal class CreateServicioMasterViewModel : BaseViewModel, 
        IServicioModule, IHasCallesList, IHasSaveServicioCommand
    {
        #region Fields

        private Servicio _currentServicio;
        private ObservableCollection<Calle> _callesList;

        #endregion

        #region Properties

        public Servicio CurrentServicio
        {
            get { return _currentServicio; }
            set { _currentServicio = value; RaiseOnPropertyChanged(); }
        }

        public SaveServicioCommand SaveServicioCommand { get; set; }

        public ObservableCollection<Calle> CallesList
        {
            get { return _callesList; }
            set { _callesList = value; RaiseOnPropertyChanged(); }
        }

        public CreateServicioViewModel ServicioViewModel { get; set; }
        public CreateLugarViewModel LugarViewModel { get; set; }
        public CreateAgenteViewModel AgenteViewModel { get; set; }
        public CreateVehiculosViewModel VehiculosViewModel { get; set; }
        public CreatePersonasViewModel PersonasViewModel { get; set; }
        public ShowResumenViewModel ResumenViewModel { get; set; }

        #endregion

        #region Constructor

        public CreateServicioMasterViewModel()
        {
        }

        public CreateServicioMasterViewModel(MemoryContext context, Servicio selectedServicio = null)
        {
            CallesList = new ObservableCollection<Calle>(CallesMock.Calles);
            InitViewModels();
            SaveServicioCommand = new SaveServicioCommand(context);
            CurrentServicio = selectedServicio ?? GenericFactory<Servicio>.Create();
            ServicioViewModel.CurrentServicio = CurrentServicio;
            LugarViewModel.CurrentServicio = CurrentServicio;
            //AgenteViewModel.CurrentServicio = CurrentServicio;
            //VehiculosViewModel.CurrentServicio = CurrentServicio;
            //PersonasViewModel.CurrentServicio = CurrentServicio;
            //ResumenViewModel.CurrentServicio = CurrentServicio;
        }

        #endregion

        #region Methods

        private void InitViewModels()
        {
            ServicioViewModel = GenericFactory<CreateServicioViewModel>.Create();
            LugarViewModel = GenericFactory<CreateLugarViewModel>.Create();
            AgenteViewModel = GenericFactory<CreateAgenteViewModel>.Create();
            VehiculosViewModel = GenericFactory<CreateVehiculosViewModel>.Create();
            PersonasViewModel = GenericFactory<CreatePersonasViewModel>.Create();
            ResumenViewModel = GenericFactory<ShowResumenViewModel>.Create();
        }

        #endregion
    }
}