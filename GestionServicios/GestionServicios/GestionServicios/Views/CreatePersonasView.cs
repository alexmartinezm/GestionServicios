using GestionServicios.Resources;
using GestionServicios.ViewModels;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreatePersonasView : ContentPage, IBaseView
    {
        public CreatePersonasView()
        {
            InitControls();
            BuildView();

            BindingContext = new CreatePersonasViewModel();
        }

        #region IBaseView implementation

        public void InitControls()
        {

        }

        public void BuildView()
        {
            Title = AppResources.Personas;
        }

        #endregion
    }
}