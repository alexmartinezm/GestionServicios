using GestionServicios.Resources;
using GestionServicios.Styles;
using GestionServicios.ViewModels.Interfaces;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreatePersonasView : ContentPage, IBaseView
    {
        #region Controls

        private Entry _dniEntry;
        private Label _datosPersonaLabel;

        #endregion

        public CreatePersonasView()
        {
            InitControls();
            BuildView();
        }

        #region IBaseView implementation

        public void InitControls()
        {
            _datosPersonaLabel = new Label
            {
                Text = AppResources.IntroducirPersona,
                Style = CustomStyles.DefaultLabels()
            };

            _dniEntry = new Entry
            {
                Placeholder = AppResources.IntroducirDni
            };
        }

        public void BuildView()
        {
            Title = AppResources.Persona;

            Content = new StackLayout()
            {
                Children =
                {
                    _datosPersonaLabel,
                    _dniEntry
                }
            };
        }

        #endregion

        #region Overrides

        protected override void OnBindingContextChanged()
        {
#pragma warning disable CS0612 // Type or member is obsolete
            _dniEntry.SetBinding<IServicioModule>(Entry.TextProperty,
                vm => vm.CurrentServicio.Vehiculo.Propietario.Dni);
#pragma warning restore CS0612 // Type or member is obsolete
            base.OnBindingContextChanged();
        }

        #endregion
    }
}