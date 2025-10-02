using System;
using System.ComponentModel.DataAnnotations;

namespace ChequeProcessingSystem.Models
{
    public class AuditLog
    {
        [Key]
        public int AuditLogId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; } = string.Empty;  // ✅ Fixes "UserName not found"

        [Required]
        [StringLength(200)]
        public string Action { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
