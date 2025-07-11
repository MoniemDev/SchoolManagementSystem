using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Database;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ConsoleDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("نظام إدارة المدرسة - عرض توضيحي للوحدة النمطية");
            Console.WriteLine("===========================================");
            
            // Initialize database
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                "SchoolManagementSystem", "school.db");
            
            // Ensure directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
            
            try
            {
                using (var dbContext = new ApplicationDbContext(dbPath))
                {
                    // Create database if it doesn't exist
                    dbContext.Database.EnsureCreated();
                    
                    // Seed initial data if database is empty
                    if (!dbContext.Users.Any())
                    {
                        await SeedInitialDataAsync(dbContext);
                    }
                    
                    // Display users
                    Console.WriteLine("\nالمستخدمون:");
                    Console.WriteLine("----------");
                    foreach (var user in dbContext.Users)
                    {
                        Console.WriteLine($"اسم المستخدم: {user.Username}, الاسم الكامل: {user.FullName}, الدور: {user.Role}");
                    }
                    
                    // Display classes
                    Console.WriteLine("\nالفصول الدراسية:");
                    Console.WriteLine("---------------");
                    foreach (var cls in dbContext.Classes)
                    {
                        Console.WriteLine($"الفصل: {cls.Name}, المستوى: {cls.Level}, عدد الطلاب: {cls.Students.Count}");
                    }
                    
                    // Display students
                    Console.WriteLine("\nالطلاب:");
                    Console.WriteLine("------");
                    foreach (var student in dbContext.Students.Include(s => s.Class))
                    {
                        Console.WriteLine($"الاسم: {student.FullName}, رقم الطالب: {student.StudentId}, الفصل: {student.Class?.Name ?? "غير محدد"}");
                    }
                    
                    // Display teachers
                    Console.WriteLine("\nالمعلمون:");
                    Console.WriteLine("--------");
                    foreach (var teacher in dbContext.Teachers)
                    {
                        Console.WriteLine($"الاسم: {teacher.FullName}, رقم المعلم: {teacher.TeacherId}, التخصص: {teacher.Specialization}");
                    }
                    
                    // Display subjects
                    Console.WriteLine("\nالمواد الدراسية:");
                    Console.WriteLine("--------------");
                    foreach (var subject in dbContext.Subjects)
                    {
                        Console.WriteLine($"المادة: {subject.Name}, الوصف: {subject.Description}");
                    }
                }
                
                Console.WriteLine("\nتم تنفيذ العرض التوضيحي بنجاح!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nحدث خطأ: {ex.Message}");
            }
        }
        
        static async Task SeedInitialDataAsync(ApplicationDbContext dbContext)
        {
            Console.WriteLine("تهيئة قاعدة البيانات بالبيانات الأولية...");
            
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
            
            // Create classes
            var class1 = new Class { Name = "الصف الأول أ", Level = 1, Capacity = 30 };
            var class2 = new Class { Name = "الصف الثاني ب", Level = 2, Capacity = 30 };
            var class3 = new Class { Name = "الصف الثالث ج", Level = 3, Capacity = 30 };
            
            dbContext.Classes.AddRange(class1, class2, class3);
            
            // Create subjects
            var mathSubject = new Subject { Name = "الرياضيات", Description = "مادة الرياضيات الأساسية" };
            var scienceSubject = new Subject { Name = "العلوم", Description = "مادة العلوم العامة" };
            var arabicSubject = new Subject { Name = "اللغة العربية", Description = "مادة اللغة العربية" };
            var englishSubject = new Subject { Name = "اللغة الإنجليزية", Description = "مادة اللغة الإنجليزية" };
            
            dbContext.Subjects.AddRange(mathSubject, scienceSubject, arabicSubject, englishSubject);
            
            // Save changes to get IDs
            await dbContext.SaveChangesAsync();
            
            // Create teachers
            var teacher1 = new Teacher
            {
                FullName = "أحمد محمد",
                TeacherId = "T001",
                DateOfBirth = new DateTime(1980, 5, 15),
                Gender = Gender.Male,
                Email = "ahmed@school.com",
                PhoneNumber = "0501234567",
                Address = "الرياض، حي النزهة",
                Specialization = "الرياضيات",
                HireDate = new DateTime(2010, 9, 1),
                IsActive = true
            };
            
            var teacher2 = new Teacher
            {
                FullName = "فاطمة علي",
                TeacherId = "T002",
                DateOfBirth = new DateTime(1985, 8, 20),
                Gender = Gender.Female,
                Email = "fatima@school.com",
                PhoneNumber = "0507654321",
                Address = "الرياض، حي الملز",
                Specialization = "العلوم",
                HireDate = new DateTime(2012, 9, 1),
                IsActive = true
            };
            
            var teacher3 = new Teacher
            {
                FullName = "محمد خالد",
                TeacherId = "T003",
                DateOfBirth = new DateTime(1982, 3, 10),
                Gender = Gender.Male,
                Email = "mohammed@school.com",
                PhoneNumber = "0509876543",
                Address = "الرياض، حي السليمانية",
                Specialization = "اللغة العربية",
                HireDate = new DateTime(2011, 9, 1),
                IsActive = true
            };
            
            dbContext.Teachers.AddRange(teacher1, teacher2, teacher3);
            
            // Create students
            var student1 = new Student
            {
                FullName = "عبدالله محمد",
                StudentId = "S001",
                DateOfBirth = new DateTime(2010, 5, 15),
                Gender = Gender.Male,
                Address = "الرياض، حي النزهة",
                ParentPhone = "0501234567",
                EnrollmentDate = new DateTime(2022, 9, 1),
                ClassId = class1.Id,
                IsActive = true
            };
            
            var student2 = new Student
            {
                FullName = "سارة أحمد",
                StudentId = "S002",
                DateOfBirth = new DateTime(2009, 8, 20),
                Gender = Gender.Female,
                Address = "الرياض، حي الملز",
                ParentPhone = "0507654321",
                EnrollmentDate = new DateTime(2021, 9, 1),
                ClassId = class2.Id,
                IsActive = true
            };
            
            var student3 = new Student
            {
                FullName = "خالد عبدالرحمن",
                StudentId = "S003",
                DateOfBirth = new DateTime(2008, 3, 10),
                Gender = Gender.Male,
                Address = "الرياض، حي السليمانية",
                ParentPhone = "0509876543",
                EnrollmentDate = new DateTime(2020, 9, 1),
                ClassId = class3.Id,
                IsActive = true
            };
            
            dbContext.Students.AddRange(student1, student2, student3);
            
            // Save all changes
            await dbContext.SaveChangesAsync();
            
            Console.WriteLine("تم تهيئة قاعدة البيانات بنجاح!");
        }
    }
}
