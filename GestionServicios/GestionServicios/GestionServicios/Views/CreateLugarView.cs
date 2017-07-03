using GestionServicios.Core.Custom_controls;
using GestionServicios.Domain.Models;
using GestionServicios.Resources;
using GestionServicios.ViewModels;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateLugarView : ContentPage, IBaseView
    {
        #region Controls

        private BindablePicker _calleBindablePicker;
        private Entry _calleEntry;
        private Label _numeroLabel;
        private Entry _numeroEntry;

        #endregion

        public CreateLugarView()
        {
            InitControls();
            BuildView();

            BindingContext = new CreateLugarViewModel();
        }

        #region IBaseView implementation

        public void InitControls()
        {
            _calleBindablePicker = new BindablePicker()
            {
                Title = AppResources.SeleccionaCalle,
                DisplayMemberPath = nameof(Calle.Valor),
                SelectedValuePath = nameof(Calle.Valor)
            };

            _calleEntry = new Entry();
            _numeroLabel = new Label()
            {
                Text = AppResources.IntroducirNumero
            };

            _numeroEntry = new Entry()
            {
                Keyboard = Keyboard.Numeric
            };
        }

        public void BuildView()
        {
            Title = AppResources.Lugar;
            Content = new StackLayout()
            {
                Padding = 5,
                Children =
                {
                    _calleBindablePicker,
                    _numeroLabel,
                    _numeroEntry
                }
            };
        }

        #endregion

        #region Overrides

        protected override void OnBindingContextChanged()
        {
#pragma warning disable CS0612 // Type or member is obsolete
            _calleBindablePicker.SetBinding<CreateLugarViewModel>(BindablePicker.ItemsSourceProperty,
                vm => vm.CallesList);
            _calleBindablePicker.SetBinding<CreateServicioMasterViewModel>(BindablePicker.SelectedItemProperty,
                vm => vm.CurrentServicio.Lugar.Calle);
            _numeroEntry.SetBinding<CreateServicioMasterViewModel>(Entry.TextProperty,
                vm => vm.CurrentServicio.Lugar.Numero);
#pragma warning restore CS0612 // Type or member is obsolete

            base.OnBindingContextChanged();
        }

        #endregion
    }
}