using GestionServicios.Domain.MemoryContext;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateLugarView : ContentPage, IBaseView
    {
        public CreateLugarView(MemoryContext context)
        {
            InitControls();
            BuildView();

            BindingContext = new CreateLugarViewModel(context);
        }

        #region IBaseView implementation

        public void InitControls()
        {

        }

        public void BuildView()
        {
            Title = "Lugar";
        }

        #endregion
    }
}