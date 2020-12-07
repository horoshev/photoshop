using System.Windows;
using System.Windows.Data;

namespace Photoshop.Converters
{
    public class BooleanToHeightConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool) value switch
            {
                true => "*",
                false => "Auto"
            };
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (string) value switch
            {
                "*" => true,
                "Auto" => false,
                _ => false
            };
        }
    }
}