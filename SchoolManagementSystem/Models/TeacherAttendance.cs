using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class TeacherAttendance
    {
        [Key]
        public int Id { get; set; }
        
        public int TeacherId { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public AttendanceStatus Status { get; set; }
        
        [MaxLength(255)]
        public string? Remarks { get; set; }
        
        public DateTime RecordedAt { get; set; } = DateTime.Now;
        
        public int? RecordedById { get; set; }
        
        // Navigation properties
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
        
        [ForeignKey("RecordedById")]
        public User? RecordedBy { get; set; }
    }
}