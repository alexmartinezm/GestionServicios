using System;
using System.Windows.Input;
using GestionServicios.Core.Navigation;
using GestionServicios.Domain.MemoryContext;
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
            NavigationService.Current.PushAsync(new CreateServicioMasterView((MemoryContext)parameter));
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}