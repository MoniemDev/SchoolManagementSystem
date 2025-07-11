using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class TeacherSubject
    {
        [Key]
        public int Id { get; set; }
        
        public int TeacherId { get; set; }
        
        public int SubjectId { get; set; }
        
        // Navigation properties
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
        
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
    }
}