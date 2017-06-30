using GestionServicios.Resources;
using GestionServicios.ViewModels;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class ShowResumenView : ContentPage, IBaseView
    {
        public ShowResumenView()
        {
            InitControls();
            BuildView();

            BindingContext = new ShowResumenViewModel();
        }

        #region IBaseView implementation

        public void InitControls()
        {

        }

        public void BuildView()
        {
            Title = AppResources.Resumen;
        }

        #endregion
    }
}