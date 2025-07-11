using System;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Database;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            // Initialize database
            InitializeDatabase();
        }
        
        private void InitializeDatabase()
        {
            try
            {
                // Get database path
                string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                    "SchoolManagementSystem");
                
                // Create directory if it doesn't exist
                if (!Directory.Exists(appDataPath))
                {
                    Directory.CreateDirectory(appDataPath);
                }
                
                string dbPath = Path.Combine(appDataPath, "school.db");
                
                // Create and migrate database
                using (var dbContext = new ApplicationDbContext(dbPath))
                {
                    dbContext.Database.EnsureCreated();
                    
                    // Seed initial data if database is empty
                    if (!dbContext.Users.Any())
                    {
                        SeedInitialData(dbContext);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تهيئة قاعدة البيانات: {ex.Message}", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void SeedInitialData(ApplicationDbContext dbContext)
        {
            // Create admin user
            var adminUser = new User
            {
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                FullName = "مدير النظام",
                Email = "admin@school.com",
                Role = UserRole.Admin,
                IsActive = true,
                CreatedAt = DateTime.Now
            };
            
            dbContext.Users.Add(adminUser);
            
            // Create teacher user
            var teacherUser = new User
            {
                Username = "teacher",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("teacher123"),
                FullName = "معلم",
                Email = "teacher@school.com",
                Role = UserRole.Teacher,
                IsActive = true,
                CreatedAt = DateTime.Now
            };
            
            dbContext.Users.Add(teacherUser);
            
            // Create supervisor user
            var supervisorUser = new User
            {
                Username = "supervisor",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("supervisor123"),
                FullName = "مشرف",
                Email = "supervisor@school.com",
                Role = UserRole.Supervisor,
                IsActive = true,
                CreatedAt = DateTime.Now
            };
            
            dbContext.Users.Add(supervisorUser);
            
            // Save changes
            dbContext.SaveChanges();
        }
    }
}