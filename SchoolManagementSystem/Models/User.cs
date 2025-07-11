using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public enum UserRole
    {
        Admin,
        Teacher,
        Supervisor
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Username { get; set; }
        
        [Required]
        public string PasswordHash { get; set; }
        
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        
        [Required]
        public UserRole Role { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime? LastLogin { get; set; }
        
        [MaxLength(255)]
        public string? Email { get; set; }
        
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        
        public byte[]? ProfileImage { get; set; }
    }
}