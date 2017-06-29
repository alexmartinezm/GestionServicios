using GestionServicios.Domain.MemoryContext;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreatePersonasView : ContentPage, IBaseView
    {
        public CreatePersonasView(MemoryContext context)
        {
            InitControls();
            BuildView();

            BindingContext = new CreatePersonasViewModel(context);
        }

        #region IBaseView implementation

        public void InitControls()
        {

        }

        public void BuildView()
        {
            Title = "Personas";
        }

        #endregion
    }
}