using System.Collections.ObjectModel;
using GestionServicios.Commands;
using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Mocks.Mocks;
using GestionServicios.ViewModels.Base;

namespace GestionServicios.ViewModels
{
    internal class ShowServiciosViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Servicio> _serviciosList;

        #endregion

        #region Properties

        public ObservableCollection<Servicio> ServiciosList
        {
            get => _serviciosList;
            set { _serviciosList = value; RaiseOnPropertyChanged(); }
        }

        public CreateServicioCommand CreateServicioCommand { get; set; }

        //public CreateServicioMasterView PageRequested { get; }

        #endregion

        public ShowServiciosViewModel(MemoryContext context)
        {
            //PageRequested = new CreateServicioMasterView(context);
            CreateServicioCommand = new CreateServicioCommand();
            ServiciosList = new ObservableCollection<Servicio>(ServiciosMock.Servicios);
        }
    }
}