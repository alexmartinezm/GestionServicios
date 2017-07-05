using GestionServicios.Converters;
using GestionServicios.Resources;
using GestionServicios.Styles;
using GestionServicios.ViewModels.Interfaces;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class ShowResumenServicioView : ContentPage, IBaseView
    {
        #region Controls

        private Label _fechaLabel;
        private Label _descripcionLabel;
        private Label _lugarLabel;
        private Label _agenteLabel;
        private Label _personaLabel;

        #endregion

        public ShowResumenServicioView()
        {
            InitControls();
            BuildView();
        }

        #region IBaseView implementation

        public void InitControls()
        {
            _fechaLabel = new Label()
            {
                Style = CustomStyles.ResumenDatosLabels()
            };

            _descripcionLabel = new Label
            {
                Style = CustomStyles.ResumenDatosLabels()
            };

            _lugarLabel = new Label
            {
                Style = CustomStyles.ResumenDatosLabels()
            };

            _agenteLabel = new Label()
            {
                Style = CustomStyles.ResumenDatosLabels()
            };

            _personaLabel = new Label()
            {
                Style = CustomStyles.ResumenDatosLabels()
            };
        }

        public void BuildView()
        {
            Title = AppResources.Resumen;

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new StackLayout
                        {
                            Children =
                            {
                                new Label
                                {
                                    Style = CustomStyles.DefaultLabels(),
                                    Text = AppResources.Fecha
                                },
                                _fechaLabel
                            }
                        },
                        new Label
                        {
                            Style = CustomStyles.DefaultLabels(),
                            Text = AppResources.Descripcion
                        },
                        _descripcionLabel,
                        new StackLayout
                        {
                            Children =
                            {
                                new Label
                                {
                                    Text = AppResources.Direccion,
                                    Style = CustomStyles.DefaultLabels()
                                },
                                _lugarLabel
                            }
                        },
                        new StackLayout
                        {
                            Children =
                            {
                                new Label
                                {
                                    Text = AppResources.Agente,
                                    Style = CustomStyles.DefaultLabels()
                                },
                                _agenteLabel
                            }
                        },
                        new StackLayout
                        {
                            Children =
                            {
                                new Label
                                {
                                    Text = AppResources.Persona,
                                    Style = CustomStyles.DefaultLabels()
                                },
                                _personaLabel
                            }
                        },
                    }
                }
            };
        }

        #endregion


        #region Overrides

        protected override void OnBindingContextChanged()
        {
#pragma warning disable CS0612 // Type or member is obsolete
            _fechaLabel.SetBinding<IServicioModule>(Label.TextProperty,
                s => s.CurrentServicio.Fecha, BindingMode.Default, new DateTimeToDateConverter());
            _descripcionLabel.SetBinding<IServicioModule>(Label.TextProperty,
                s => s.CurrentServicio.Descripcion);
            _lugarLabel.SetBinding<IServicioModule>(Label.TextProperty, s => s.CurrentServicio.Lugar,
                        BindingMode.Default, new LugarToReadableConverter());
            _agenteLabel.SetBinding<IServicioModule>(Label.TextProperty, 
                s => s.CurrentServicio.Agente.Tip);
            _personaLabel.SetBinding<IServicioModule>(Label.TextProperty, 
                s => s.CurrentServicio.Persona.Dni);
#pragma warning restore CS0612 // Type or member is obsolete

            base.OnBindingContextChanged();
        }

        #endregion
    }
}