using System;
using System.Windows.Input;
using GestionServicios.Core.Navigation;
using Xamarin.Forms;

namespace GestionServicios.Core.Commands
{
    /// <summary>
    /// Command que navega a la pantalla TPage con PushAsync.
    /// </summary>
    /// <typeparam name="TPage">Pantalla que hereda de Page y es instanciable</typeparam>
    public class NewPageCommand<TPage> : ICommand where TPage : Page
    {
        private readonly TPage _page;

        public NewPageCommand(params object[] args)
        {
            //_page = new TPage();
            _page = (TPage)Activator.CreateInstance(typeof(TPage), args);
        }

        #region ICommand implementation

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NavigationService.Current.PushAsync(_page);
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}
