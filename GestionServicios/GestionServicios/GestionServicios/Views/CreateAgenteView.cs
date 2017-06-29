using GestionServicios.Domain.MemoryContext;
using GestionServicios.ViewModels;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateAgenteView : ContentPage, IBaseView
    {
        public CreateAgenteView(MemoryContext context)
        {
            InitControls();
            BuildView();

            BindingContext = new CreateAgenteViewModel(context);
        }

        #region IBaseView implementation

        public void InitControls()
        {

        }

        public void BuildView()
        {
            Title = "Agente";
        }

        #endregion
    }
}