using System.Collections.ObjectModel;
using System.Windows.Input;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class StudentsViewModel : ViewModelBase
    {
        private ObservableCollection<Student> _students;
        private Student _selectedStudent;
        private string _searchText;
        private bool _isLoading;
        private string _errorMessage;

        public ObservableCollection<Student> Students
        {
            get => _students;
            set => SetProperty(ref _students, value);
        }

        public Student SelectedStudent
        {
            get => _selectedStudent;
            set => SetProperty(ref _selectedStudent, value);
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    // Filter students based on search text
                    FilterStudents();
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
        public ICommand AddStudentCommand { get; }
        public ICommand EditStudentCommand { get; }
        public ICommand DeleteStudentCommand { get; }
        public ICommand RefreshCommand { get; }

        public StudentsViewModel()
        {
            Students = new ObservableCollection<Student>();
            
            // Initialize commands
            AddStudentCommand = new RelayCommand(_ => AddStudent());
            EditStudentCommand = new RelayCommand(_ => EditStudent(), _ => SelectedStudent != null);
            DeleteStudentCommand = new RelayCommand(_ => DeleteStudent(), _ => SelectedStudent != null);
            RefreshCommand = new RelayCommand(_ => LoadStudents());
            
            // Load students
            LoadStudents();
        }

        private void LoadStudents()
        {
            // This is a placeholder. In a real implementation, this would load students from the database.
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

        private void FilterStudents()
        {
            // This is a placeholder. In a real implementation, this would filter students based on search text.
        }

        private void AddStudent()
        {
            // This is a placeholder. In a real implementation, this would open a dialog to add a new student.
        }

        private void EditStudent()
        {
            // This is a placeholder. In a real implementation, this would open a dialog to edit the selected student.
        }

        private void DeleteStudent()
        {
            // This is a placeholder. In a real implementation, this would delete the selected student.
        }
    }
}