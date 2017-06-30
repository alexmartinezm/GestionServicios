using GestionServicios.Resources;
using GestionServicios.ViewModels;
using GestionServicios.ViewModels.Interfaces;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateServicioMasterView : TabbedPage, IBaseView
    {
        #region Fields
        
        private ToolbarItem _saveToolbarItem;
        private readonly CreateServicioMasterViewModel _viewModel;

        #endregion

        #region Constructor

        public CreateServicioMasterView(CreateServicioMasterViewModel viewModel)
        {
            //_context = context;
            _viewModel = viewModel;
            InitControls();
            BuildView();

            BindingContext = _viewModel;
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
            _saveToolbarItem.SetBinding<IHasSaveServicioCommand>(MenuItem.CommandProperty,
                s => s.SaveServicioCommand);
            _saveToolbarItem.SetBinding<IServicioModule>(MenuItem.CommandParameterProperty,
                s => s.CurrentServicio);
#pragma warning restore 612
        }

        public void BuildView()
        {
            Title = AppResources.CrearServicio;
            ToolbarItems.Add(_saveToolbarItem);
            //Children.Add(new CreateServicioView(_viewModel));
            //Children.Add(new CreateLugarView(_viewModel));
            //Children.Add(new CreateAgenteView(_viewModel));
            //Children.Add(new CreateVehiculosView(_viewModel));
            //Children.Add(new CreatePersonasView(_viewModel));
            //Children.Add(new ShowResumenView(_viewModel));
            Children.Add((Page)_viewModel.ServicioViewModel.View);
            Children.Add((Page)_viewModel.LugarViewModel.View);
        }

        #endregion
    }
}