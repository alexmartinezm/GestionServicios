using Xamarin.Forms;

namespace GestionServicios.Styles
{
    internal class CustomStyles
    {
        public static Style DefaultLabels()
        {
            return new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter
                    {
                        Property = Label.FontAttributesProperty,
                        Value = FontAttributes.Bold,
                    },
                    new Setter
                    {
                        Property = View.MarginProperty,
                        Value = new Thickness(10).Top,
                    }
                }
            };
        }

        public static Style ResumenDatosLabels()
        {
            return new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter
                    {
                        Property = View.MarginProperty,
                        Value = new Thickness(10, 0, 0, 10),
                    }
                }
            };
        }
    }
}