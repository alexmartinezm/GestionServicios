using GestionServicios.Core.Custom_controls;
using GestionServicios.Domain.Models;
using GestionServicios.Resources;
using GestionServicios.ViewModels.Interfaces;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateLugarView : ContentPage, IBaseView
    {
        #region Controls

        private Picker _calleBindablePicker;
        private Label _numeroLabel;
        private Entry _numeroEntry;

        #endregion

        public CreateLugarView()
        {
            InitControls();
            BuildView();
        }

        #region IBaseView implementation

        public void InitControls()
        {
            _calleBindablePicker = new BindablePicker
            {
                Title = AppResources.SeleccionaCalle,
                DisplayMemberPath = nameof(Calle.Valor),
                SelectedValuePath = nameof(Calle.Valor),
            };

            _numeroLabel = new Label
            {
                Text = AppResources.IntroducirNumero
            };

            _numeroEntry = new Entry
            {
                Keyboard = Keyboard.Numeric
            };
        }

        public void BuildView()
        {
            Title = AppResources.Lugar;
            Content = new StackLayout
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

            _calleBindablePicker.SetBinding<IHasCallesList>(BindablePicker.ItemsSourceProperty,
                i => i.CallesList);
            _calleBindablePicker.SetBinding<IServicioModule>(BindablePicker.SelectedItemProperty,
                vm => vm.CurrentServicio.Lugar.Calle);
            _calleBindablePicker.SetBinding<IServicioModule>(BindablePicker.SelectedValueProperty,
                vm => vm.CurrentServicio.Lugar.Calle.Valor);
            _numeroEntry.SetBinding<IServicioModule>(Entry.TextProperty,
                vm => vm.CurrentServicio.Lugar.Numero);
#pragma warning restore CS0612 // Type or member is obsolete

            base.OnBindingContextChanged();
        }

        #endregion
    }
}