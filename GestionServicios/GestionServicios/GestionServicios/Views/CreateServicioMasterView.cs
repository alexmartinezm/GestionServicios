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

        public CreateServicioMasterView()
        {
        }

        public CreateServicioMasterView(CreateServicioMasterViewModel viewModel)
        {
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
                Text = AppResources.GuardarCambios,
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
            Children.Add((Page)_viewModel.ServicioViewModel.View);
            Children.Add((Page)_viewModel.LugarViewModel.View);
            Children.Add((Page)_viewModel.AgenteViewModel.View);
            Children.Add((Page)_viewModel.VehiculosViewModel.View);
            Children.Add((Page)_viewModel.PersonasViewModel.View);
            Children.Add((Page)_viewModel.ResumenServicioViewModel.View);
        }

        #endregion

        #region Overrides

        protected override bool OnBackButtonPressed()
        {
            return _viewModel.OnBackButtonPressed();
        }

        #endregion
    }
}