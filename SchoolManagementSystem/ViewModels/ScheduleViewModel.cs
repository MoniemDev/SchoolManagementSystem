using System.Collections.ObjectModel;
using System.Windows.Input;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class ScheduleViewModel : ViewModelBase
    {
        private ObservableCollection<ClassSchedule> _schedules;
        private ClassSchedule _selectedSchedule;
        private Class _selectedClass;
        private ObservableCollection<Class> _classes;
        private bool _isLoading;
        private string _errorMessage;

        public ObservableCollection<ClassSchedule> Schedules
        {
            get => _schedules;
            set => SetProperty(ref _schedules, value);
        }

        public ClassSchedule SelectedSchedule
        {
            get => _selectedSchedule;
            set => SetProperty(ref _selectedSchedule, value);
        }

        public Class SelectedClass
        {
            get => _selectedClass;
            set
            {
                if (SetProperty(ref _selectedClass, value))
                {
                    // Load schedules for the selected class
                    LoadSchedulesForClass();
                }
            }
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
        public ICommand AddScheduleCommand { get; }
        public ICommand EditScheduleCommand { get; }
        public ICommand DeleteScheduleCommand { get; }
        public ICommand PrintScheduleCommand { get; }
        public ICommand RefreshCommand { get; }

        public ScheduleViewModel()
        {
            Schedules = new ObservableCollection<ClassSchedule>();
            Classes = new ObservableCollection<Class>();
            
            // Initialize commands
            AddScheduleCommand = new RelayCommand(_ => AddSchedule(), _ => SelectedClass != null);
            EditScheduleCommand = new RelayCommand(_ => EditSchedule(), _ => SelectedSchedule != null);
            DeleteScheduleCommand = new RelayCommand(_ => DeleteSchedule(), _ => SelectedSchedule != null);
            PrintScheduleCommand = new RelayCommand(_ => PrintSchedule(), _ => SelectedClass != null && Schedules.Count > 0);
            RefreshCommand = new RelayCommand(_ => LoadClasses());
            
            // Load classes
            LoadClasses();
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

        private void LoadSchedulesForClass()
        {
            // This is a placeholder. In a real implementation, this would load schedules for the selected class.
            if (SelectedClass == null) return;
            
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

        private void AddSchedule()
        {
            // This is a placeholder. In a real implementation, this would open a dialog to add a new schedule.
        }

        private void EditSchedule()
        {
            // This is a placeholder. In a real implementation, this would open a dialog to edit the selected schedule.
        }

        private void DeleteSchedule()
        {
            // This is a placeholder. In a real implementation, this would delete the selected schedule.
        }

        private void PrintSchedule()
        {
            // This is a placeholder. In a real implementation, this would print the schedule for the selected class.
        }
    }
}