using GestionServicios.Resources;
using GestionServicios.Styles;
using GestionServicios.ViewModels.Interfaces;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateAgenteView : ContentPage, IBaseView
    {
        private Entry _tipEntry;
        private Label _tipLabel;

        public CreateAgenteView()
        {
            InitControls();
            BuildView();
        }

        #region IBaseView implementation

        public void InitControls()
        {
            _tipLabel = new Label
            {
                Text = AppResources.IntroducirTip,
                Style = CustomStyles.DefaultLabels()
            };

            _tipEntry = new Entry
            {
                Keyboard = Keyboard.Numeric
            };
        }

        public void BuildView()
        {
            Title = AppResources.Agente;

            Content = new StackLayout()
            {
                Children =
                {
                    _tipLabel,
                    _tipEntry
                }
            };
        }

        #endregion

        #region Overrides

        protected override void OnBindingContextChanged()
        {
#pragma warning disable CS0612 // Type or member is obsolete
            _tipEntry.SetBinding<IServicioModule>(Entry.TextProperty, i => i.CurrentServicio.Agente.Tip);
#pragma warning restore CS0612 // Type or member is obsolete

            base.OnBindingContextChanged();
        }

        #endregion
    }
}