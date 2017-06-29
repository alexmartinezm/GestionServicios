using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Repository.Factories;
using GestionServicios.ViewModels.Base;

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
        }

    }

    internal interface IServicioModule
    {
        Servicio CurrentServicio { get; set; }
    }
}