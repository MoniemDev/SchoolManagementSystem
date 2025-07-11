using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Database;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private int _totalStudents;
        private int _totalTeachers;
        private int _totalClasses;
        private int _activeStudents;
        private int _activeTeachers;
        private ObservableCollection<Notification> _recentNotifications;
        private bool _isLoading = true;
        private string _errorMessage;

        public int TotalStudents
        {
            get => _totalStudents;
            set => SetProperty(ref _totalStudents, value);
        }

        public int TotalTeachers
        {
            get => _totalTeachers;
            set => SetProperty(ref _totalTeachers, value);
        }

        public int TotalClasses
        {
            get => _totalClasses;
            set => SetProperty(ref _totalClasses, value);
        }

        public int ActiveStudents
        {
            get => _activeStudents;
            set => SetProperty(ref _activeStudents, value);
        }

        public int ActiveTeachers
        {
            get => _activeTeachers;
            set => SetProperty(ref _activeTeachers, value);
        }

        public ObservableCollection<Notification> RecentNotifications
        {
            get => _recentNotifications;
            set => SetProperty(ref _recentNotifications, value);
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

        public ICommand RefreshCommand { get; }

        public DashboardViewModel()
        {
            RecentNotifications = new ObservableCollection<Notification>();
            RefreshCommand = new RelayCommand(_ => LoadDashboardData());
            
            // Load data
            LoadDashboardData();
        }

        private async void LoadDashboardData()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;

                await Task.Run(() =>
                {
                    try
                    {
                        // Get database path
                        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                            "SchoolManagementSystem", "school.db");

                        using (var dbContext = new ApplicationDbContext(dbPath))
                        {
                            // Get counts
                            TotalStudents = dbContext.Students.Count();
                            TotalTeachers = dbContext.Teachers.Count();
                            TotalClasses = dbContext.Classes.Count();
                            ActiveStudents = dbContext.Students.Count(s => s.IsActive);
                            ActiveTeachers = dbContext.Teachers.Count(t => t.IsActive);

                            // Get recent notifications
                            var notifications = dbContext.Notifications
                                .Include(n => n.CreatedBy)
                                .Include(n => n.Class)
                                .OrderByDescending(n => n.CreatedAt)
                                .Take(5)
                                .ToList();

                            // Update UI on main thread
                            System.Windows.Application.Current.Dispatcher.Invoke(() =>
                            {
                                RecentNotifications.Clear();
                                foreach (var notification in notifications)
                                {
                                    RecentNotifications.Add(notification);
                                }
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = $"خطأ في تحميل البيانات: {ex.Message}";
                    }
                });
            }
            catch (Exception ex)
            {
                ErrorMessage = $"خطأ: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}