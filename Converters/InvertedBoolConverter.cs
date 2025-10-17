using System.Globalization;
using MediCare.Models;

namespace MediCare.Converters
{
    public class InvertedBoolConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string icon = Icons.Visibility_off;
            if (value != null)
                icon = (bool)value ? Icons.Visibility_off : Icons.Visibility_on;
            return icon;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}