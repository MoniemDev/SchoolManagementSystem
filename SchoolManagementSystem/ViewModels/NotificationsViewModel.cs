using System.Collections.ObjectModel;
using System.Windows.Input;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class NotificationsViewModel : ViewModelBase
    {
        private ObservableCollection<Notification> _notifications;
        private Notification _selectedNotification;
        private string _newNotificationTitle;
        private string _newNotificationContent;
        private Class _selectedClass;
        private ObservableCollection<Class> _classes;
        private bool _isLoading;
        private string _errorMessage;

        public ObservableCollection<Notification> Notifications
        {
            get => _notifications;
            set => SetProperty(ref _notifications, value);
        }

        public Notification SelectedNotification
        {
            get => _selectedNotification;
            set => SetProperty(ref _selectedNotification, value);
        }

        public string NewNotificationTitle
        {
            get => _newNotificationTitle;
            set => SetProperty(ref _newNotificationTitle, value);
        }

        public string NewNotificationContent
        {
            get => _newNotificationContent;
            set => SetProperty(ref _newNotificationContent, value);
        }

        public Class SelectedClass
        {
            get => _selectedClass;
            set => SetProperty(ref _selectedClass, value);
        }

        public ObservableCollection<Class> Classes
        {
            get => _classes;
            set => SetProperty(ref _classes, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        // Commands
        public ICommand SendNotificationCommand { get; }
        public ICommand DeleteNotificationCommand { get; }
        public ICommand RefreshCommand { get; }

        public NotificationsViewModel()
        {
            Notifications = new ObservableCollection<Notification>();
            Classes = new ObservableCollection<Class>();
            
            // Initialize commands
            SendNotificationCommand = new RelayCommand(_ => SendNotification(), CanSendNotification);
            DeleteNotificationCommand = new RelayCommand(_ => DeleteNotification(), _ => SelectedNotification != null);
            RefreshCommand = new RelayCommand(_ => LoadNotifications());
            
            // Load classes and notifications
            LoadClasses();
            LoadNotifications();
        }

        private bool CanSendNotification(object parameter)
        {
            return !string.IsNullOrWhiteSpace(NewNotificationTitle) && 
                   !string.IsNullOrWhiteSpace(NewNotificationContent) && 
                   SelectedClass != null;
        }

        private void LoadClasses()
        {
            // This is a placeholder. In a real implementation, this would load classes from the database.
            IsLoading = true;
            ErrorMessage = string.Empty;
            
            // Simulate loading
            System.Threading.Tasks.Task.Delay(1000).ContinueWith(_ =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    IsLoading = false;
                });
            });
        }

        private void LoadNotifications()
        {
            // This is a placeholder. In a real implementation, this would load notifications from the database.
            IsLoading = true;
            ErrorMessage = string.Empty;
            
            // Simulate loading
            System.Threading.Tasks.Task.Delay(1000).ContinueWith(_ =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    IsLoading = false;
                });
            });
        }

        private void SendNotification()
        {
            // This is a placeholder. In a real implementation, this would send a new notification.
            if (!CanSendNotification(null)) return;
            
            // Clear form after sending
            NewNotificationTitle = string.Empty;
            NewNotificationContent = string.Empty;
            SelectedClass = null;
            
            // Refresh notifications
            LoadNotifications();
        }

        private void DeleteNotification()
        {
            // This is a placeholder. In a real implementation, this would delete the selected notification.
            if (SelectedNotification == null) return;
            
            // Refresh notifications
            LoadNotifications();
        }
    }
}