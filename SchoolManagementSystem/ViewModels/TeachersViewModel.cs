using System.Collections.ObjectModel;
using System.Windows.Input;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class TeachersViewModel : ViewModelBase
    {
        private ObservableCollection<Teacher> _teachers;
        private Teacher _selectedTeacher;
        private string _searchText;
        private bool _isLoading;
        private string _errorMessage;

        public ObservableCollection<Teacher> Teachers
        {
            get => _teachers;
            set => SetProperty(ref _teachers, value);
        }

        public Teacher SelectedTeacher
        {
            get => _selectedTeacher;
            set => SetProperty(ref _selectedTeacher, value);
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    // Filter teachers based on search text
                    FilterTeachers();
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
        public ICommand AddTeacherCommand { get; }
        public ICommand EditTeacherCommand { get; }
        public ICommand DeleteTeacherCommand { get; }
        public ICommand RefreshCommand { get; }

        public TeachersViewModel()
        {
            Teachers = new ObservableCollection<Teacher>();
            
            // Initialize commands
            AddTeacherCommand = new RelayCommand(_ => AddTeacher());
            EditTeacherCommand = new RelayCommand(_ => EditTeacher(), _ => SelectedTeacher != null);
            DeleteTeacherCommand = new RelayCommand(_ => DeleteTeacher(), _ => SelectedTeacher != null);
            RefreshCommand = new RelayCommand(_ => LoadTeachers());
            
            // Load teachers
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            // This is a placeholder. In a real implementation, this would load teachers from the database.
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

        private void FilterTeachers()
        {
            // This is a placeholder. In a real implementation, this would filter teachers based on search text.
        }

        private void AddTeacher()
        {
            // This is a placeholder. In a real implementation, this would open a dialog to add a new teacher.
        }

        private void EditTeacher()
        {
            // This is a placeholder. In a real implementation, this would open a dialog to edit the selected teacher.
        }

        private void DeleteTeacher()
        {
            // This is a placeholder. In a real implementation, this would delete the selected teacher.
        }
    }
}