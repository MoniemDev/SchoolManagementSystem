using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class BackupRecord
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FilePath { get; set; }
        
        [Required]
        public DateTime BackupDate { get; set; } = DateTime.Now;
        
        [MaxLength(255)]
        public string? Description { get; set; }
        
        public bool IsAutomatic { get; set; }
        
        public long FileSizeBytes { get; set; }
        
        public int? CreatedById { get; set; }
        
        // Navigation property
        [ForeignKey("CreatedById")]
        public User? CreatedBy { get; set; }
    }
}