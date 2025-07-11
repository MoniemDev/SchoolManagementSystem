using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public enum DayOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public class ClassSchedule
    {
        [Key]
        public int Id { get; set; }
        
        public int ClassId { get; set; }
        
        public int SubjectId { get; set; }
        
        public int TeacherId { get; set; }
        
        [Required]
        public DayOfWeek Day { get; set; }
        
        [Required]
        public TimeSpan StartTime { get; set; }
        
        [Required]
        public TimeSpan EndTime { get; set; }
        
        [MaxLength(100)]
        public string? Room { get; set; }
        
        // Navigation properties
        [ForeignKey("ClassId")]
        public Class Class { get; set; }
        
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
    }
}