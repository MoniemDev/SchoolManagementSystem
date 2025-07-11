using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        
        [Required, MaxLength(20)]
        public string TeacherId { get; set; } // Employee ID
        
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        public Gender Gender { get; set; }
        
        [MaxLength(255)]
        public string? Address { get; set; }
        
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        
        [MaxLength(255)]
        public string? Email { get; set; }
        
        [MaxLength(500)]
        public string? Qualifications { get; set; }
        
        public DateTime JoinDate { get; set; } = DateTime.Now;
        
        public bool IsActive { get; set; } = true;
        
        public byte[]? Photo { get; set; }
        
        // Navigation properties
        public ICollection<Subject> Subjects { get; set; }
        
        public ICollection<TeacherAttendance> Attendances { get; set; }
        
        // User account if exists
        public int? UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}