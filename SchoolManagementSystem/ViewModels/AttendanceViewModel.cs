using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class AttendanceViewModel : ViewModelBase
    {
        private ObservableCollection<StudentAttendance> _studentAttendances;
        private ObservableCollection<TeacherAttendance> _teacherAttendances;
        private bool _isStudentAttendanceSelected = true;
        private DateTime _selectedDate = DateTime.Today;
        private Class _selectedClass;
        private ObservableCollection<Class> _classes;
        private bool _isLoading;
        private string _errorMessage;

        public ObservableCollection<StudentAttendance> StudentAttendances
        {
            get => _studentAttendances;
            set => SetProperty(ref _studentAttendances, value);
        }

        public ObservableCollection<TeacherAttendance> TeacherAttendances
        {
            get => _teacherAttendances;
            set => SetProperty(ref _teacherAttendances, value);
        }

        public bool IsStudentAttendanceSelected
        {
            get => _isStudentAttendanceSelected;
            set
            {
                if (SetProperty(ref _isStudentAttendanceSelected, value))
                {
                    // Load appropriate attendance data
                    LoadAttendanceData();
                }
            }
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (SetProperty(ref _selectedDate, value))
                {
                    // Load attendance for the selected date
                    LoadAttendanceData();
                }
            }
        }

        public Class SelectedClass
        {
            get => _selectedClass;
            set
            {
                if (SetProperty(ref _selectedClass, value))
                {
                    // Load attendance for the selected class
                    LoadAttendanceData();
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
        public ICommand ToggleAttendanceTypeCommand { get; }
        public ICommand SaveAttendanceCommand { get; }
        public ICommand ExportAttendanceCommand { get; }
        public ICommand RefreshCommand { get; }

        public AttendanceViewModel()
        {
            StudentAttendances = new ObservableCollection<StudentAttendance>();
            TeacherAttendances = new ObservableCollection<TeacherAttendance>();
            Classes = new ObservableCollection<Class>();
            
            // Initialize commands
            ToggleAttendanceTypeCommand = new RelayCommand(_ => IsStudentAttendanceSelected = !IsStudentAttendanceSelected);
            SaveAttendanceCommand = new RelayCommand(_ => SaveAttendance());
            ExportAttendanceCommand = new RelayCommand(_ => ExportAttendance());
            RefreshCommand = new RelayCommand(_ => LoadAttendanceData());
            
            // Load classes
            LoadClasses();
            
            // Load initial attendance data
            LoadAttendanceData();
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

        private void LoadAttendanceData()
        {
            // This is a placeholder. In a real implementation, this would load attendance data based on the selected type, date, and class.
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

        private void SaveAttendance()
        {
            // This is a placeholder. In a real implementation, this would save the attendance data.
        }

        private void ExportAttendance()
        {
            // This is a placeholder. In a real implementation, this would export attendance data to PDF or Excel.
        }
    }
}