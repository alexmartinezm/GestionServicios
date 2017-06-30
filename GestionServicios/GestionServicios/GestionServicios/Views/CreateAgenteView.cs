using GestionServicios.Resources;
using GestionServicios.ViewModels;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateAgenteView : ContentPage, IBaseView
    {
        public CreateAgenteView()
        {
            InitControls();
            BuildView();

            BindingContext = new CreateAgenteViewModel();
        }

        #region IBaseView implementation

        public void InitControls()
        {

        }

        public void BuildView()
        {
            Title = AppResources.Agente;
        }

        #endregion
    }
}