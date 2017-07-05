using GestionServicios.Resources;
using GestionServicios.Styles;
using GestionServicios.ViewModels.Interfaces;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateVehiculosView : ContentPage, IBaseView
    {
        #region Controls

        private Entry _matriculaEntry;
        private Label _matriculaLabel;
        private Label _personaLabel;
        private Entry _dniEntry;

        #endregion

        public CreateVehiculosView()
        {
            InitControls();
            BuildView();
        }

        #region IBaseView implementation

        public void InitControls()
        {
            _matriculaLabel = new Label
            {
                Text = AppResources.IntroducirMatricula,
                Style = CustomStyles.DefaultLabels()
            };
            _matriculaEntry = new Entry
            {
                Placeholder = AppResources.EjemploMatricula
            };

            _personaLabel = new Label
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
            Title = AppResources.Vehiculo;

            Content = new StackLayout
            {
                Children =
                {
                    _matriculaLabel,
                    _matriculaEntry,
                    _personaLabel,
                    _dniEntry
                }
            };
        }

        #endregion

        #region Overrides

        protected override void OnBindingContextChanged()
        {
#pragma warning disable CS0612 // Type or member is obsolete
            _matriculaEntry.SetBinding<IServicioModule>(Entry.TextProperty, 
                vm => vm.CurrentServicio.Vehiculo.Matricula);
            _dniEntry.SetBinding<IServicioModule>(Entry.TextProperty,
                vm => vm.CurrentServicio.Vehiculo.Propietario.Dni);
#pragma warning restore CS0612 // Type or member is obsolete

            base.OnBindingContextChanged();
        }

        #endregion
    }
}