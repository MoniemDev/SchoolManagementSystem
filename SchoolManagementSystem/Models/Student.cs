using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Student
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        
        [Required, MaxLength(20)]
        public string StudentId { get; set; } // School ID number
        
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        public Gender Gender { get; set; }
        
        [MaxLength(255)]
        public string? Address { get; set; }
        
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        
        [MaxLength(255)]
        public string? ParentName { get; set; }
        
        [MaxLength(20)]
        public string? ParentPhone { get; set; }
        
        [MaxLength(255)]
        public string? ParentEmail { get; set; }
        
        [MaxLength(500)]
        public string? HealthNotes { get; set; }
        
        public byte[]? Photo { get; set; }
        
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        
        public bool IsActive { get; set; } = true;
        
        // Foreign key
        public int ClassId { get; set; }
        
        // Navigation property
        [ForeignKey("ClassId")]
        public Class Class { get; set; }
        
        public ICollection<StudentAttendance> Attendances { get; set; }
        
        public ICollection<Grade> Grades { get; set; }
    }
}