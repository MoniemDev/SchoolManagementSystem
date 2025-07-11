using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public enum NotificationType
    {
        Announcement,
        Reminder,
        Alert,
        Other
    }

    public class Notification
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public NotificationType Type { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime? ExpiresAt { get; set; }
        
        public bool IsRead { get; set; } = false;
        
        public int? ClassId { get; set; } // If null, it's for all classes
        
        public int CreatedById { get; set; }
        
        // Navigation properties
        [ForeignKey("ClassId")]
        public Class? Class { get; set; }
        
        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }
    }
}