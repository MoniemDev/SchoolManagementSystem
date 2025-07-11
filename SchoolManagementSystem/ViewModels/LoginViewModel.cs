using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Database;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Views;

namespace SchoolManagementSystem.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _errorMessage;
        private bool _isLoading;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private bool CanExecuteLogin(object parameter)
        {
            var passwordBox = parameter as System.Windows.Controls.PasswordBox;
            return !string.IsNullOrWhiteSpace(Username) && 
                   passwordBox != null && 
                   !string.IsNullOrWhiteSpace(passwordBox.Password) && 
                   !IsLoading;
        }

        private async void ExecuteLogin(object parameter)
        {
            try
            {
                var passwordBox = parameter as System.Windows.Controls.PasswordBox;
                if (passwordBox == null) return;

                string password = passwordBox.Password;
                
                IsLoading = true;
                ErrorMessage = string.Empty;

                // Get database path
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                    "SchoolManagementSystem", "school.db");

                // Authenticate user
                using (var dbContext = new ApplicationDbContext(dbPath))
                {
                    var user = await dbContext.Users
                        .FirstOrDefaultAsync(u => u.Username == Username && u.IsActive);

                    if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                    {
                        ErrorMessage = "اسم المستخدم أو كلمة المرور غير صحيحة";
                        return;
                    }

                    // Update last login
                    user.LastLogin = DateTime.Now;
                    await dbContext.SaveChangesAsync();

                    // Open main window based on role
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Window mainWindow = new MainWindow(user);
                        mainWindow.Show();
                        
                        // Close login window
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window is LoginWindow)
                            {
                                window.Close();
                                break;
                            }
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"خطأ في تسجيل الدخول: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}