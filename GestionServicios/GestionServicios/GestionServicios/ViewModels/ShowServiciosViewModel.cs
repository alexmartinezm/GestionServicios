using System.Collections.ObjectModel;
using GestionServicios.Core.Commands;
using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Mocks.Mocks;
using GestionServicios.ViewModels.Base;
using GestionServicios.Views;

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
            get { return _serviciosList; }
            set { _serviciosList = value; RaiseOnPropertyChanged(); }
        }

        public NewPageCommand<CreateServicioView> NewPageCommand { get; set; }

        #endregion

        public ShowServiciosViewModel(MemoryContext context)
        {
            NewPageCommand = new NewPageCommand<CreateServicioView>();
            ServiciosList = new ObservableCollection<Servicio>(ServiciosMock.Servicios);
        }
    }
}