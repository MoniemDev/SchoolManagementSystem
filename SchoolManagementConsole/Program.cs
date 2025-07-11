using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("نظام إدارة المدرسة - عرض توضيحي للوحدة النمطية");
            Console.WriteLine("===========================================");
            
            // Simulate database with in-memory collections
            var users = new List<User>
            {
                new User { Id = 1, Username = "admin", FullName = "مدير النظام", Role = "Admin", IsActive = true },
                new User { Id = 2, Username = "teacher", FullName = "معلم", Role = "Teacher", IsActive = true },
                new User { Id = 3, Username = "supervisor", FullName = "مشرف", Role = "Supervisor", IsActive = true }
            };
            
            var classes = new List<Class>
            {
                new Class { Id = 1, Name = "الصف الأول أ", Level = 1, Capacity = 30 },
                new Class { Id = 2, Name = "الصف الثاني ب", Level = 2, Capacity = 30 },
                new Class { Id = 3, Name = "الصف الثالث ج", Level = 3, Capacity = 30 }
            };
            
            var subjects = new List<Subject>
            {
                new Subject { Id = 1, Name = "الرياضيات", Description = "مادة الرياضيات الأساسية" },
                new Subject { Id = 2, Name = "العلوم", Description = "مادة العلوم العامة" },
                new Subject { Id = 3, Name = "اللغة العربية", Description = "مادة اللغة العربية" },
                new Subject { Id = 4, Name = "اللغة الإنجليزية", Description = "مادة اللغة الإنجليزية" }
            };
            
            var teachers = new List<Teacher>
            {
                new Teacher { Id = 1, FullName = "أحمد محمد", TeacherId = "T001", Specialization = "الرياضيات", IsActive = true },
                new Teacher { Id = 2, FullName = "فاطمة علي", TeacherId = "T002", Specialization = "العلوم", IsActive = true },
                new Teacher { Id = 3, FullName = "محمد خالد", TeacherId = "T003", Specialization = "اللغة العربية", IsActive = true }
            };
            
            var students = new List<Student>
            {
                new Student { Id = 1, FullName = "عبدالله محمد", StudentId = "S001", ClassId = 1, IsActive = true },
                new Student { Id = 2, FullName = "سارة أحمد", StudentId = "S002", ClassId = 2, IsActive = true },
                new Student { Id = 3, FullName = "خالد عبدالرحمن", StudentId = "S003", ClassId = 3, IsActive = true }
            };
            
            // Display users
            Console.WriteLine("\nالمستخدمون:");
            Console.WriteLine("----------");
            foreach (var user in users)
            {
                Console.WriteLine($"اسم المستخدم: {user.Username}, الاسم الكامل: {user.FullName}, الدور: {user.Role}");
            }
            
            // Display classes
            Console.WriteLine("\nالفصول الدراسية:");
            Console.WriteLine("---------------");
            foreach (var cls in classes)
            {
                var studentCount = students.Count(s => s.ClassId == cls.Id);
                Console.WriteLine($"الفصل: {cls.Name}, المستوى: {cls.Level}, عدد الطلاب: {studentCount}");
            }
            
            // Display students
            Console.WriteLine("\nالطلاب:");
            Console.WriteLine("------");
            foreach (var student in students)
            {
                var className = classes.FirstOrDefault(c => c.Id == student.ClassId)?.Name ?? "غير محدد";
                Console.WriteLine($"الاسم: {student.FullName}, رقم الطالب: {student.StudentId}, الفصل: {className}");
            }
            
            // Display teachers
            Console.WriteLine("\nالمعلمون:");
            Console.WriteLine("--------");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"الاسم: {teacher.FullName}, رقم المعلم: {teacher.TeacherId}, التخصص: {teacher.Specialization}");
            }
            
            // Display subjects
            Console.WriteLine("\nالمواد الدراسية:");
            Console.WriteLine("--------------");
            foreach (var subject in subjects)
            {
                Console.WriteLine($"المادة: {subject.Name}, الوصف: {subject.Description}");
            }
            
            Console.WriteLine("\nتم تنفيذ العرض التوضيحي بنجاح!");
            Console.WriteLine("\nاضغط أي مفتاح للخروج...");
            Console.ReadKey();
        }
    }
    
    // Simple model classes for the demo
    class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
    
    class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Capacity { get; set; }
    }
    
    class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    
    class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string TeacherId { get; set; }
        public string Specialization { get; set; }
        public bool IsActive { get; set; }
    }
    
    class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string StudentId { get; set; }
        public int ClassId { get; set; }
        public bool IsActive { get; set; }
    }
}
