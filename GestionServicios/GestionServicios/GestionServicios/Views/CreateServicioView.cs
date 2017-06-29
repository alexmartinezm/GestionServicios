using GestionServicios.Domain.MemoryContext;
using GestionServicios.Resources;
using GestionServicios.ViewModels;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateServicioView : ContentPage, IBaseView
    {
        private DatePicker _fechaDatePicker;
        private Editor _descripcionEditor;

        public CreateServicioView(MemoryContext context)
        {
            InitControls();
            BuildView();
            BindingContext = new CreateServicioViewModel(context);
        }

        #region IBaseView implementation

        public void InitControls()
        {
            _fechaDatePicker = new DatePicker
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            _descripcionEditor = new Editor
            {
                HeightRequest = 100,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

#pragma warning disable CS0612 // Type or member is obsolete
            _fechaDatePicker.SetBinding<IServicioModule>(DatePicker.DateProperty, 
                s => s.CurrentServicio.Fecha);
            _descripcionEditor.SetBinding<IServicioModule>(Editor.TextProperty, 
                s => s.CurrentServicio.Descripcion);
#pragma warning restore CS0612 // Type or member is obsolete
        }

        public void BuildView()
        {
            Title = AppResources.Servicio;

            Content = new StackLayout
            {
                Padding = 5,
                Children =
                {
                    new Label
                    {
                        Text = AppResources.Fecha
                    },
                    _fechaDatePicker,
                    new Label
                    {
                        Margin = new Thickness(20).Top,
                        Text = AppResources.Descripcion
                    },
                    _descripcionEditor
                }
            };
        }

        #endregion
    }
}