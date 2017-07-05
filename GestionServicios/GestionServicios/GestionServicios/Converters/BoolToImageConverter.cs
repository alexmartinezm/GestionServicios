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
            var result = (bool) value;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}