using GestionServicios.Domain.MemoryContext;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class ShowResumenView : ContentPage, IBaseView
    {
        public ShowResumenView(MemoryContext context)
        {
            InitControls();
            BuildView();
        }

        #region IBaseView implementation

        public void InitControls()
        {

        }

        public void BuildView()
        {
            Title = "Resumen";
        }

        #endregion
    }
}