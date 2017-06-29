using Xamarin.Forms;

namespace GestionServicios.Styles
{
    internal class CustomStyles
    {
        public Style DefaultLabels()
        {
            return new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter()
                    {
                        Property = Label.FontAttributesProperty,
                        Value = FontAttributes.Bold,
                    },
                    new Setter()
                    {
                        Property = View.MarginProperty,
                        Value = new Thickness(10).Top,
                    }
                }
            };
        }
    }
}