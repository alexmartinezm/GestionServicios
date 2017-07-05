using System;
using System.Globalization;
using Xamarin.Forms;

namespace GestionServicios.Converters
{
    internal class BoolToImageConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "ic_borrador_valido.png" : "ic_borrador.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}