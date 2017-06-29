using System;
using System.Windows.Input;
using GestionServicios.Core.Navigation;
using Xamarin.Forms;

namespace GestionServicios.Core.Commands
{
    /// <summary>
    /// Command que navega a la pantalla TPage
    /// </summary>
    /// <typeparam name="TPage"></typeparam>
    public class NewPageCommand<TPage> : ICommand where TPage : Page, new()
    {
        private readonly TPage _page;

        public NewPageCommand()
        {
            _page = new TPage();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NavigationService.Current.PushAsync(_page);
        }

        public event EventHandler CanExecuteChanged;
    }
}
