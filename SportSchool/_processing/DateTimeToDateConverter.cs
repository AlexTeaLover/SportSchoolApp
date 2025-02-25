using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace SportSchool._processing
{
    public class DateTimeToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            { 
                DateTime date = (DateTime)value;
                return date.ToShortDateString();
            }
            return "-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
