using GestionServicios.Core.Behaviors;
using GestionServicios.Resources;
using GestionServicios.Styles;
using GestionServicios.ViewModels.Interfaces;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateServicioView : ContentPage, IBaseView
    {
        private DatePicker _fechaDatePicker;
        private Editor _descripcionEditor;

        public CreateServicioView()
        {
            InitControls();
            BuildView();
        }

        #region IBaseView implementation

        public void InitControls()
        {
            _fechaDatePicker = new DatePicker();

            _descripcionEditor = new Editor
            {
                MinimumHeightRequest = 20,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            _descripcionEditor.Behaviors.Add(new EditorBehavior());
        }

        public void BuildView()
        {
            Title = AppResources.Servicio;

            Content = new StackLayout
            {
                Padding = 5,
                Children =
                {
                    new StackLayout
                    {
                        Children =
                        {
                            new Label
                            {
                                Style = new CustomStyles().DefaultLabels(),
                                Text = AppResources.Fecha
                            },
                            _fechaDatePicker
                        }
                    },
                    new Label
                    {
                        Style = new CustomStyles().DefaultLabels(),
                        Text = AppResources.Descripcion
                    },
                    _descripcionEditor
                }
            };
        }

        #endregion

        protected override void OnBindingContextChanged()
        {
#pragma warning disable CS0612 // Type or member is obsolete
            _fechaDatePicker.SetBinding<IServicioModule>(DatePicker.DateProperty,
                s => s.CurrentServicio.Fecha);
            _descripcionEditor.SetBinding<IServicioModule>(Editor.TextProperty,
                s => s.CurrentServicio.Descripcion);
#pragma warning restore CS0612 // Type or member is obsolete

            base.OnBindingContextChanged();
        }
    }
}