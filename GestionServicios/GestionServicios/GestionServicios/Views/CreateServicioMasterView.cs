using GestionServicios.Domain.MemoryContext;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateServicioMasterView : TabbedPage
    {
        public CreateServicioMasterView(MemoryContext context)
        {
            Title = "Crear servicio";
            BuildViews(context);
        }

        private void BuildViews(MemoryContext context)
        {
            Children.Add(new CreateServicioView(context));
            Children.Add(new CreateLugarView(context));
            Children.Add(new CreateAgenteView(context));
            Children.Add(new CreateVehiculosView(context));
            Children.Add(new CreatePersonasView(context));
            Children.Add(new ShowResumenView(context));
        }
    }
}