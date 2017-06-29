using System;
using System.Globalization;
using System.Text;
using GestionServicios.Domain.Models;
using Xamarin.Forms;

namespace GestionServicios.Converters
{
    internal class LugarToReadableConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var lugar = (Lugar) value;
            var builder = new StringBuilder();
            builder
                .Append(lugar.Calle.Valor)
                .Append(", ")
                .Append(lugar.Numero);
            return builder.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}