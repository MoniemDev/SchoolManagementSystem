using System;
using System.Globalization;
using System.Windows.Data;

namespace SchoolManagementSystem.Helpers.Converters
{
    public class BoolToSidebarWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isOpen)
            {
                return isOpen ? 220 : 50;
            }
            
            return 220;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}