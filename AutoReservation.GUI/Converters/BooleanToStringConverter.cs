using System;
using System.Windows.Data;

namespace AutoReservation.GUI.Converters
{
    class BooleanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return "False";
            }
            return "True";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value as string != null && ((string)value).ToLower() == "true";
        }
    }
}
