using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.ViewModels;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class ShowServiciosView : ContentPage
    {
        #region Fields

        private ListView _serviciosListView;
        private ToolbarItem _createServicioToolbarItem;

        #endregion

        #region Constructor

        public ShowServiciosView(MemoryContext context)
        {
            InitControls();
            BuildControls();

            BindingContext = new ShowServiciosViewModel(context);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inicializa los controles de la vista.
        /// </summary>
        private void InitControls()
        {
            _serviciosListView = new ListView()
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
                    lugarLabel.SetBinding<Servicio>(Label.TextProperty, s => s.Lugar.Calle.Valor);
                    agenteLabel.SetBinding<Servicio>(Label.TextProperty, s => s.Agente.Tip);
                    isValidImage.SetBinding(Image.SourceProperty, nameof(Servicio.IsValid));
#pragma warning restore 612
                    // Devolvemos un ViewCell con los controles creados
                    var grid = new Grid()
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
                    File = "ic_action_add.png"
                }
#pragma warning disable 612
            };
            _createServicioToolbarItem.SetBinding<ShowServiciosViewModel>(MenuItem.CommandProperty, 
                vm => vm.NewPageCommand);
#pragma warning restore 612
        }

        /// <summary>
        /// Construye y muestra la vista.
        /// </summary>
        private void BuildControls()
        {
            ToolbarItems.Add(_createServicioToolbarItem);
            Content = new StackLayout
            {
                Children =
                {
                    _serviciosListView
                }
            };
        }

        #endregion
    }
}
