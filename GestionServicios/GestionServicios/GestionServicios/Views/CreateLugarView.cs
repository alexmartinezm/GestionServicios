using GestionServicios.Resources;
using GestionServicios.ViewModels;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateLugarView : ContentPage, IBaseView
    {
        public CreateLugarView()
        {
            InitControls();
            BuildView();

            BindingContext = new CreateLugarViewModel();
        }

        #region IBaseView implementation

        public void InitControls()
        {

        }

        public void BuildView()
        {
            Title = AppResources.Lugar;
        }

        #endregion
    }
}