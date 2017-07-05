using System;
using GestionServicios.Converters;
using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Resources;
using GestionServicios.ViewModels;
using GestionServicios.ViewModels.Interfaces;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class ShowServiciosView : ContentPage, IBaseView
    {
        #region Fields

        private ListView _serviciosListView;
        private ToolbarItem _createServicioToolbarItem;
        private readonly MemoryContext _memoryContext;

        #endregion

        #region Constructor

        public ShowServiciosView(MemoryContext memoryContext)
        {
            _memoryContext = memoryContext;
            InitControls();
            BuildView();

            BindingContext = new ShowServiciosViewModel(memoryContext);
        }

        #endregion

        #region IBaseView implementation

        /// <summary>
        /// Inicializa los controles de la vista.
        /// </summary>
        public void InitControls()
        {
            _serviciosListView = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    // Creamos los controles
                    var fechaLabel = new Label();
                    var agenteLabel = new Label();
                    var lugarLabel = new Label();
                    var isValidImage = new Image();

                    // Bindings
                    fechaLabel.SetBinding(Label.TextProperty, nameof(Servicio.Fecha));
                    // Deshabilitamos la advertencia que indica que está obsoleto
#pragma warning disable 612
                    lugarLabel.SetBinding<Servicio>(Label.TextProperty, s => s.Lugar,
                        BindingMode.Default, new LugarToReadableConverter());
                    agenteLabel.SetBinding<Servicio>(Label.TextProperty, s => s.Agente.Tip);
                    isValidImage.SetBinding(Image.SourceProperty, nameof(Servicio.IsValid), 
                        BindingMode.Default, new BoolToImageConverter());
#pragma warning restore 612
                    // Devolvemos un ViewCell con los controles creados
                    var grid = new Grid
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children =
                        {
                            {fechaLabel, 0, 0},
                            {agenteLabel, 0, 1},
                            {lugarLabel, 1, 1},
                            {isValidImage, 2, 1}
                        }
                    };

                    return new ViewCell
                    {
                        View = grid
                    };
                })
            };

            _createServicioToolbarItem = new ToolbarItem
            {
                Icon = new FileImageSource
                {
                    File = "ic_action_add.png",
                },
                CommandParameter = _memoryContext
            };
        }

        /// <summary>
        /// Construye y muestra la vista.
        /// </summary>
        public void BuildView()
        {
            Title = AppResources.NombreApp;
            ToolbarItems.Add(_createServicioToolbarItem);
            Content = new StackLayout
            {
                Padding = 5,
                Children =
                {
                    _serviciosListView
                }
            };

#pragma warning disable 612
            _serviciosListView.SetBinding<IShowServicios>(ListView.ItemsSourceProperty,
                i => i.ServiciosList);
            _serviciosListView.SetBinding<IShowServicios>(ListView.SelectedItemProperty,
                i => i.SelectedServicio);
            _createServicioToolbarItem.SetBinding<IHasCreateServicioCommand>(MenuItem.CommandProperty,
                i => i.CreateServicioCommand);
#pragma warning restore 612
        }

        #endregion

        #region Overrides

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_serviciosListView != null) _serviciosListView.SelectedItem = null;
        }

        #endregion
    }

}
