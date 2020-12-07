using System.Windows;
using System.Windows.Data;

namespace Photoshop.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool) value switch
            {
                true => Visibility.Visible,
                false => Visibility.Collapsed
            };
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (Visibility) value switch
            {
                Visibility.Visible => true,
                Visibility.Collapsed => false,
                Visibility.Hidden => false,
                _ => false
            };
        }
    }
}