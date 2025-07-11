using System.Collections.ObjectModel;
using System.Windows.Input;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private User _currentUser;
        private ViewModelBase _currentViewModel;
        private string _pageTitle;
        private bool _isSidebarOpen = true;

        public User CurrentUser
        {
            get => _currentUser;
            set => SetProperty(ref _currentUser, value);
        }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (SetProperty(ref _currentViewModel, value))
                {
                    OnPropertyChanged(nameof(IsStudentsViewActive));
                    OnPropertyChanged(nameof(IsTeachersViewActive));
                    OnPropertyChanged(nameof(IsClassesViewActive));
                    OnPropertyChanged(nameof(IsScheduleViewActive));
                    OnPropertyChanged(nameof(IsGradesViewActive));
                    OnPropertyChanged(nameof(IsAttendanceViewActive));
                    OnPropertyChanged(nameof(IsNotificationsViewActive));
                    OnPropertyChanged(nameof(IsSettingsViewActive));
                }
            }
        }

        public string PageTitle
        {
            get => _pageTitle;
            set => SetProperty(ref _pageTitle, value);
        }

        public bool IsSidebarOpen
        {
            get => _isSidebarOpen;
            set => SetProperty(ref _isSidebarOpen, value);
        }

        // Navigation state properties
        public bool IsStudentsViewActive => CurrentViewModel is StudentsViewModel;
        public bool IsTeachersViewActive => CurrentViewModel is TeachersViewModel;
        public bool IsClassesViewActive => CurrentViewModel is ClassesViewModel;
        public bool IsScheduleViewActive => CurrentViewModel is ScheduleViewModel;
        public bool IsGradesViewActive => CurrentViewModel is GradesViewModel;
        public bool IsAttendanceViewActive => CurrentViewModel is AttendanceViewModel;
        public bool IsNotificationsViewActive => CurrentViewModel is NotificationsViewModel;
        public bool IsSettingsViewActive => CurrentViewModel is SettingsViewModel;

        // Commands
        public ICommand ToggleSidebarCommand { get; }
        public ICommand NavigateCommand { get; }
        public ICommand LogoutCommand { get; }

        public MainViewModel(User user)
        {
            CurrentUser = user;
            
            // Initialize commands
            ToggleSidebarCommand = new RelayCommand(_ => IsSidebarOpen = !IsSidebarOpen);
            NavigateCommand = new RelayCommand(ExecuteNavigate);
            LogoutCommand = new RelayCommand(ExecuteLogout);
            
            // Set default view
            NavigateToDashboard();
        }

        private void ExecuteNavigate(object parameter)
        {
            if (parameter is string viewName)
            {
                switch (viewName)
                {
                    case "Dashboard":
                        NavigateToDashboard();
                        break;
                    case "Students":
                        NavigateToStudents();
                        break;
                    case "Teachers":
                        NavigateToTeachers();
                        break;
                    case "Classes":
                        NavigateToClasses();
                        break;
                    case "Schedule":
                        NavigateToSchedule();
                        break;
                    case "Grades":
                        NavigateToGrades();
                        break;
                    case "Attendance":
                        NavigateToAttendance();
                        break;
                    case "Notifications":
                        NavigateToNotifications();
                        break;
                    case "Settings":
                        NavigateToSettings();
                        break;
                }
            }
        }

        private void ExecuteLogout(object parameter)
        {
            // Show login window
            var loginWindow = new Views.LoginWindow();
            loginWindow.Show();
            
            // Close main window
            if (parameter is System.Windows.Window window)
            {
                window.Close();
            }
        }

        // Navigation methods
        private void NavigateToDashboard()
        {
            PageTitle = "لوحة التحكم";
            CurrentViewModel = new DashboardViewModel();
        }

        private void NavigateToStudents()
        {
            PageTitle = "إدارة الطلاب";
            CurrentViewModel = new StudentsViewModel();
        }

        private void NavigateToTeachers()
        {
            PageTitle = "إدارة المعلمين";
            CurrentViewModel = new TeachersViewModel();
        }

        private void NavigateToClasses()
        {
            PageTitle = "إدارة الفصول";
            CurrentViewModel = new ClassesViewModel();
        }

        private void NavigateToSchedule()
        {
            PageTitle = "جدول الحصص";
            CurrentViewModel = new ScheduleViewModel();
        }

        private void NavigateToGrades()
        {
            PageTitle = "إدارة الدرجات";
            CurrentViewModel = new GradesViewModel();
        }

        private void NavigateToAttendance()
        {
            PageTitle = "سجل الحضور";
            CurrentViewModel = new AttendanceViewModel();
        }

        private void NavigateToNotifications()
        {
            PageTitle = "الإشعارات والتنبيهات";
            CurrentViewModel = new NotificationsViewModel();
        }

        private void NavigateToSettings()
        {
            PageTitle = "الإعدادات";
            CurrentViewModel = new SettingsViewModel();
        }
    }
}