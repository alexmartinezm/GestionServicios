using System;
using System.Windows.Input;
using GestionServicios.Core.Navigation;
using GestionServicios.Domain.MemoryContext;
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
            var mainViewModel = new CreateServicioMasterViewModel((MemoryContext) parameter)
            {
                ServicioViewModel = {View = new CreateServicioView()}
            };

            NavigationService.Current.PushAsync(new CreateServicioMasterView(mainViewModel));
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}