using System.Collections.ObjectModel;
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
            get { return _serviciosList; }
            set { _serviciosList = value; RaiseOnPropertyChanged(); }
        }

        #endregion

        public ShowServiciosViewModel(MemoryContext context)
        {
            ServiciosList = new ObservableCollection<Servicio>(ServiciosMock.Servicios);
        }
    }
}