using System;
using System.Collections.ObjectModel;
using GestionServicios.Commands;
using GestionServicios.Core.Navigation;
using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Repository.Factories;
using GestionServicios.Resources;
using GestionServicios.ViewModels.Base;
using GestionServicios.ViewModels.Interfaces;
using GestionServicios.Views;
using Xamarin.Forms;

namespace GestionServicios.ViewModels
{
    internal class ShowServiciosViewModel : BaseViewModel, IShowServicios, IHasCreateServicioCommand
    {
        #region Fields

        private ObservableCollection<Servicio> _serviciosList;
        private Servicio _selectedServicio;
        private readonly MemoryContext _memoryContext;

        #endregion

        #region Properties

        public ObservableCollection<Servicio> ServiciosList
        {
            get { return _serviciosList; }
            set { _serviciosList = value; RaiseOnPropertyChanged(); }
        }

        public CreateServicioCommand CreateServicioCommand { get; set; }

        public Servicio SelectedServicio
        {
            get { return _selectedServicio; }
            set
            {
                _selectedServicio = value;
                RaiseOnPropertyChanged();
                if (SelectedServicio != null)
                {
                    var masterViewModel = GenericFactory<CreateServicioMasterViewModel>.Create(_memoryContext,
                    SelectedServicio);

                    NavigationService.Current
                        .PushAsync(GenericFactory<CreateServicioMasterView>.Create(masterViewModel));
                }
            }
        }

        #endregion

        public ShowServiciosViewModel(MemoryContext memoryContext)
        {
            _memoryContext = memoryContext;
            CreateServicioCommand = new CreateServicioCommand();
            var repo = new RepositoryInMemoryFactory<Servicio>(_memoryContext).Instance;
            ServiciosList = new ObservableCollection<Servicio>(repo.Find(r => true));

            MessagingCenter.Subscribe<Servicio>(this, MessagingResources.ServicioCreado, (servicio) =>
            {
                ServiciosList.Add(servicio);
            });

            MessagingCenter.Subscribe<Servicio>(this, MessagingResources.ServicioActualizado, (servicio) =>
            {
                var position = ServiciosList.IndexOf(servicio);
                ServiciosList.RemoveAt(position);
                ServiciosList.Insert(position, servicio);
            });
        }
    }
}