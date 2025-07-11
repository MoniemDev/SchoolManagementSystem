using System;
using System.Globalization;
using System.Windows.Data;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Helpers.Converters
{
    public class RoleToPermissionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is UserRole role && parameter is string permission)
            {
                // Admin has access to everything
                if (role == UserRole.Admin)
                    return true;
                
                // Check specific permissions based on role and requested permission
                switch (permission)
                {
                    case "Students":
                        return role == UserRole.Admin || role == UserRole.Supervisor;
                    
                    case "Teachers":
                        return role == UserRole.Admin || role == UserRole.Supervisor;
                    
                    case "Classes":
                        return role == UserRole.Admin || role == UserRole.Supervisor;
                    
                    case "Settings":
                        return role == UserRole.Admin;
                    
                    // Other modules are accessible by all roles
                    default:
                        return true;
                }
            }
            
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}