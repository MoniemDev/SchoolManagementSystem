using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SchoolManagementSystem.Helpers.Converters
{
    public class BoolToStatusBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isActive)
            {
                return isActive ? new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#4CAF50")) : 
                                  new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#F44336"));
            }
            
            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}