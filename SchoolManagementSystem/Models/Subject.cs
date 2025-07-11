using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(10)]
        public string? Code { get; set; }
        
        [MaxLength(500)]
        public string? Description { get; set; }
        
        public int? TotalMarks { get; set; } = 100;
        
        public int? PassingMarks { get; set; } = 50;
        
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public ICollection<Teacher> Teachers { get; set; }
    }
}