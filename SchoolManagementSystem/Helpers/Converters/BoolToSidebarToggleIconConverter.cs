using System;
using System.Globalization;
using System.Windows.Data;

namespace SchoolManagementSystem.Helpers.Converters
{
    public class BoolToSidebarToggleIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isOpen)
            {
                return isOpen ? "\uE010" : "\uE011"; // Left arrow : Right arrow
            }
            
            return "\uE010";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}