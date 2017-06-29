using GestionServicios.Domain.MemoryContext;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateVehiculosView : ContentPage, IBaseView
    {
        public CreateVehiculosView(MemoryContext context)
        {
            InitControls();
            BuildView();

            BindingContext = new CreateVehiculosViewModel(context);
        }

        #region IBaseView implementation

        public void InitControls()
        {

        }

        public void BuildView()
        {
            Title = "Vehículos";
        }

        #endregion
    }
}