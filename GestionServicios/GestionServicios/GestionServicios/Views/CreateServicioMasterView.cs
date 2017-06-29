using GestionServicios.Domain.MemoryContext;
using GestionServicios.Resources;
using GestionServicios.ViewModels;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateServicioMasterView : TabbedPage, IBaseView
    {
        #region Fields

        private readonly MemoryContext _context;
        private ToolbarItem _saveToolbarItem;

        #endregion

        #region Constructor

        public CreateServicioMasterView(MemoryContext context)
        {
            _context = context;
            InitControls();
            BuildView();
        }

        #endregion

        #region IBaseView implementation

        public void InitControls()
        {
            _saveToolbarItem = new ToolbarItem
            {
                Icon = new FileImageSource
                {
                    File = "ic_action_file_upload.png"
                }
            };

#pragma warning disable 612
            _saveToolbarItem.SetBinding<CreateServicioMasterViewModel>(MenuItem.CommandProperty,
                vm => vm.Servicio);
#pragma warning restore 612
        }

        public void BuildView()
        {
            Title = AppResources.CrearServicio;
            ToolbarItems.Add(_saveToolbarItem);
            Children.Add(new CreateServicioView(_context));
            Children.Add(new CreateLugarView(_context));
            Children.Add(new CreateAgenteView(_context));
            Children.Add(new CreateVehiculosView(_context));
            Children.Add(new CreatePersonasView(_context));
            Children.Add(new ShowResumenView(_context));
        }

        #endregion
    }
}