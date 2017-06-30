using GestionServicios.Resources;
using GestionServicios.ViewModels;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateVehiculosView : ContentPage, IBaseView
    {
        public CreateVehiculosView()
        {
            InitControls();
            BuildView();

            BindingContext = new CreateVehiculosViewModel();
        }

        #region IBaseView implementation

        public void InitControls()
        {

        }

        public void BuildView()
        {
            Title = AppResources.Vehiculos;
        }

        #endregion
    }
}