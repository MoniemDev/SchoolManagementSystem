using System.Collections.ObjectModel;
using System.Windows.Input;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class ClassesViewModel : ViewModelBase
    {
        private ObservableCollection<Class> _classes;
        private Class _selectedClass;
        private string _searchText;
        private bool _isLoading;
        private string _errorMessage;

        public ObservableCollection<Class> Classes
        {
            get => _classes;
            set => SetProperty(ref _classes, value);
        }

        public Class SelectedClass
        {
            get => _selectedClass;
            set => SetProperty(ref _selectedClass, value);
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    // Filter classes based on search text
                    FilterClasses();
                }
            }
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
        public ICommand AddClassCommand { get; }
        public ICommand EditClassCommand { get; }
        public ICommand DeleteClassCommand { get; }
        public ICommand ViewStudentsCommand { get; }
        public ICommand RefreshCommand { get; }

        public ClassesViewModel()
        {
            Classes = new ObservableCollection<Class>();
            
            // Initialize commands
            AddClassCommand = new RelayCommand(_ => AddClass());
            EditClassCommand = new RelayCommand(_ => EditClass(), _ => SelectedClass != null);
            DeleteClassCommand = new RelayCommand(_ => DeleteClass(), _ => SelectedClass != null);
            ViewStudentsCommand = new RelayCommand(_ => ViewStudents(), _ => SelectedClass != null);
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

        private void FilterClasses()
        {
            // This is a placeholder. In a real implementation, this would filter classes based on search text.
        }

        private void AddClass()
        {
            // This is a placeholder. In a real implementation, this would open a dialog to add a new class.
        }

        private void EditClass()
        {
            // This is a placeholder. In a real implementation, this would open a dialog to edit the selected class.
        }

        private void DeleteClass()
        {
            // This is a placeholder. In a real implementation, this would delete the selected class.
        }

        private void ViewStudents()
        {
            // This is a placeholder. In a real implementation, this would navigate to the students view filtered by the selected class.
        }
    }
}