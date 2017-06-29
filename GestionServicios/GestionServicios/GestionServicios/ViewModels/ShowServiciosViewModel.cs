using System.Collections.ObjectModel;
using GestionServicios.Commands;
using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Mocks.Mocks;
using GestionServicios.Repository.Factories;
using GestionServicios.ViewModels.Base;
using Xamarin.Forms;

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

        #endregion

        public ShowServiciosViewModel(MemoryContext context)
        {
            CreateServicioCommand = new CreateServicioCommand();
            var repo = new RepositoryInMemoryFactory<Servicio>(context).Instance;
            ServiciosList = new ObservableCollection<Servicio>(repo.Find(r => true));
            MessagingCenter.Subscribe<Servicio>(this, "ServicioCreado", (servicio) =>
            {
                ServiciosList.Add(servicio);
            });
        }
    }
}