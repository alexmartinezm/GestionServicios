using System;
using System.Windows.Input;
using GestionServicios.Core.Navigation;
using GestionServicios.Domain.MemoryContext;
using GestionServicios.Repository.Factories;
using GestionServicios.ViewModels;
using GestionServicios.Views;

namespace GestionServicios.Commands
{
    public class CreateServicioCommand : ICommand
    {
        #region ICommand implementation

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Especificamos null ya que el método CreateInstance no reconoce los parámetros con
            // valor por defecto
            var masterViewModel = GenericFactory<CreateServicioMasterViewModel>
                .Create((MemoryContext)parameter, null);
            masterViewModel.ServicioViewModel.View = GenericFactory<CreateServicioView>.Create();
            masterViewModel.LugarViewModel.View = GenericFactory<CreateLugarView>.Create();
            masterViewModel.AgenteViewModel.View = GenericFactory<CreateAgenteView>.Create();
            masterViewModel.VehiculosViewModel.View = GenericFactory<CreateVehiculosView>.Create();
            masterViewModel.PersonasViewModel.View = GenericFactory<CreatePersonasView>.Create();
            masterViewModel.ResumenViewModel.View = GenericFactory<ShowResumenView>.Create();

            NavigationService.Current.PushAsync(GenericFactory<CreateServicioMasterView>.Create(masterViewModel));
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}