using System.Collections.ObjectModel;
using System.Windows.Input;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class GradesViewModel : ViewModelBase
    {
        private ObservableCollection<Grade> _grades;
        private Grade _selectedGrade;
        private Student _selectedStudent;
        private ObservableCollection<Student> _students;
        private Subject _selectedSubject;
        private ObservableCollection<Subject> _subjects;
        private bool _isLoading;
        private string _errorMessage;

        public ObservableCollection<Grade> Grades
        {
            get => _grades;
            set => SetProperty(ref _grades, value);
        }

        public Grade SelectedGrade
        {
            get => _selectedGrade;
            set => SetProperty(ref _selectedGrade, value);
        }

        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                if (SetProperty(ref _selectedStudent, value))
                {
                    // Load grades for the selected student
                    LoadGradesForStudent();
                }
            }
        }

        public ObservableCollection<Student> Students
        {
            get => _students;
            set => SetProperty(ref _students, value);
        }

        public Subject SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                if (SetProperty(ref _selectedSubject, value))
                {
                    // Filter grades for the selected subject
                    FilterGradesBySubject();
                }
            }
        }

        public ObservableCollection<Subject> Subjects
        {
            get => _subjects;
            set => SetProperty(ref _subjects, value);
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
        public ICommand AddGradeCommand { get; }
        public ICommand EditGradeCommand { get; }
        public ICommand DeleteGradeCommand { get; }
        public ICommand ExportGradesCommand { get; }
        public ICommand RefreshCommand { get; }

        public GradesViewModel()
        {
            Grades = new ObservableCollection<Grade>();
            Students = new ObservableCollection<Student>();
            Subjects = new ObservableCollection<Subject>();
            
            // Initialize commands
            AddGradeCommand = new RelayCommand(_ => AddGrade(), _ => SelectedStudent != null);
            EditGradeCommand = new RelayCommand(_ => EditGrade(), _ => SelectedGrade != null);
            DeleteGradeCommand = new RelayCommand(_ => DeleteGrade(), _ => SelectedGrade != null);
            ExportGradesCommand = new RelayCommand(_ => ExportGrades(), _ => Grades.Count > 0);
            RefreshCommand = new RelayCommand(_ => LoadStudents());
            
            // Load students and subjects
            LoadStudents();
            LoadSubjects();
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

        private void LoadSubjects()
        {
            // This is a placeholder. In a real implementation, this would load subjects from the database.
        }

        private void LoadGradesForStudent()
        {
            // This is a placeholder. In a real implementation, this would load grades for the selected student.
            if (SelectedStudent == null) return;
            
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

        private void FilterGradesBySubject()
        {
            // This is a placeholder. In a real implementation, this would filter grades by the selected subject.
        }

        private void AddGrade()
        {
            // This is a placeholder. In a real implementation, this would open a dialog to add a new grade.
        }

        private void EditGrade()
        {
            // This is a placeholder. In a real implementation, this would open a dialog to edit the selected grade.
        }

        private void DeleteGrade()
        {
            // This is a placeholder. In a real implementation, this would delete the selected grade.
        }

        private void ExportGrades()
        {
            // This is a placeholder. In a real implementation, this would export grades to PDF or Excel.
        }
    }
}