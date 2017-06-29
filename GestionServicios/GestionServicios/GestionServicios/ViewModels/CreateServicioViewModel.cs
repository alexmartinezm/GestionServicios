using System;
using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Repository.Factories;
using GestionServicios.ViewModels.Base;
using GestionServicios.ViewModels.Interfaces;
using Xamarin.Forms;

namespace GestionServicios.ViewModels
{
    internal class CreateServicioViewModel : BaseViewModel, IServicioModule
    {
        #region Fields

        private Servicio _currentServicio;

        #endregion

        #region Properties

        public Servicio CurrentServicio
        {
            get => _currentServicio;
            set { _currentServicio = value; RaiseOnPropertyChanged(); }
        }

        #endregion

        public CreateServicioViewModel(MemoryContext context)
        {
            CurrentServicio = new EntityFactory<Servicio>().Create();

            var servicio = new RepositoryInMemoryFactory<Servicio>(context).Instance.Create(CurrentServicio);
            MessagingCenter.Send(servicio, "ServicioCreado");
        }
    }
}