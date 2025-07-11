using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public enum GradeType
    {
        Quiz,
        Assignment,
        MidTerm,
        FinalExam,
        Project,
        Other
    }

    public class Grade
    {
        [Key]
        public int Id { get; set; }
        
        public int StudentId { get; set; }
        
        public int SubjectId { get; set; }
        
        [Required]
        public GradeType Type { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public decimal ObtainedMarks { get; set; }
        
        [Required]
        public decimal TotalMarks { get; set; }
        
        public DateTime Date { get; set; } = DateTime.Now;
        
        [MaxLength(255)]
        public string? Remarks { get; set; }
        
        public int? RecordedById { get; set; }
        
        // Navigation properties
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        
        [ForeignKey("RecordedById")]
        public User? RecordedBy { get; set; }
    }
}