using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public enum AttendanceStatus
    {
        Present,
        Absent,
        Late,
        Excused
    }

    public class StudentAttendance
    {
        [Key]
        public int Id { get; set; }
        
        public int StudentId { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public AttendanceStatus Status { get; set; }
        
        [MaxLength(255)]
        public string? Remarks { get; set; }
        
        public DateTime RecordedAt { get; set; } = DateTime.Now;
        
        public int? RecordedById { get; set; }
        
        // Navigation properties
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        
        [ForeignKey("RecordedById")]
        public User? RecordedBy { get; set; }
    }
}