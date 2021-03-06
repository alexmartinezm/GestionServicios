using System.Collections.ObjectModel;
using GestionServicios.Commands;
using GestionServicios.Core.Extensions;
using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Factories;
using GestionServicios.Mocks.Mocks;
using GestionServicios.Repository.Factories;
using GestionServicios.ViewModels.Base;
using GestionServicios.ViewModels.Interfaces;
using GestionServicios.Views;

namespace GestionServicios.ViewModels
{
    internal class CreateServicioMasterViewModel : BaseViewModel, 
        IServicioModule, IHasCallesList, IHasSaveServicioCommand
    {
        #region Fields

        private Servicio _currentServicio;
        private ObservableCollection<Calle> _callesList;
        private MemoryContext _context;

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
        public ShowResumenServicioViewModel ResumenServicioViewModel { get; set; }

        #endregion

        #region Constructor

        public CreateServicioMasterViewModel()
        {
        }

        public CreateServicioMasterViewModel(MemoryContext context, Servicio selectedServicio = default(Servicio))
        {
            _context = context;
            CallesList = new ObservableCollection<Calle>(CallesMock.Calles);
            InitViewModels();
            InitViews();

            SaveServicioCommand = new SaveServicioCommand(_context);

            CurrentServicio = selectedServicio ?? new ServicioFactory().Create();

            LinkViewModels();
        }

        #endregion

        #region Methods

        private void InitViewModels()
        {
            ServicioViewModel = new GenericFactory<CreateServicioViewModel>().Create();
            LugarViewModel = new GenericFactory<CreateLugarViewModel>().Create();
            AgenteViewModel = new GenericFactory<CreateAgenteViewModel>().Create();
            VehiculosViewModel = new GenericFactory<CreateVehiculosViewModel>().Create();
            PersonasViewModel = new GenericFactory<CreatePersonasViewModel>().Create();
            ResumenServicioViewModel = new GenericFactory<ShowResumenServicioViewModel>().Create();
        }

        private void InitViews()
        {
            ServicioViewModel.View = new GenericFactory<CreateServicioView>().Create();
            LugarViewModel.View = new GenericFactory<CreateLugarView>().Create();
            AgenteViewModel.View = new GenericFactory<CreateAgenteView>().Create();
            VehiculosViewModel.View = new GenericFactory<CreateVehiculosView>().Create();
            PersonasViewModel.View = new GenericFactory<CreatePersonasView>().Create();
            ResumenServicioViewModel.View = new GenericFactory<ShowResumenServicioView>().Create();
        }

        private void LinkViewModels()
        {
            ServicioViewModel.CurrentServicio = CurrentServicio;
            LugarViewModel.CurrentServicio = CurrentServicio;
            AgenteViewModel.CurrentServicio = CurrentServicio;
            VehiculosViewModel.CurrentServicio = CurrentServicio;
            PersonasViewModel.CurrentServicio = CurrentServicio;
            ResumenServicioViewModel.CurrentServicio = CurrentServicio;
        }

        #endregion

        public bool OnBackButtonPressed()
        {
            var isSaved = new RepositoryInMemoryFactory<Servicio>(_context).Instance
                .Find(s => s.Id == CurrentServicio.Id).HasResults();

            if (isSaved)
            {
                //MessagingCenter.Send();
            }

            return isSaved;
        }
    }
}