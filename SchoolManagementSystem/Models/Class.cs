using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(10)]
        public string? Grade { get; set; } // e.g., "1st", "2nd", etc.
        
        [MaxLength(100)]
        public string? Room { get; set; }
        
        public int? MaxCapacity { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public ICollection<Student> Students { get; set; }
        
        public ICollection<ClassSchedule> Schedules { get; set; }
    }
}