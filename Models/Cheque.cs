using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChequeProcessingSystem.Models
{
    public class Cheque
    {
        [Key]
        public int ChequeId { get; set; }

        [Required, StringLength(50)]
        public string ChequeNumber { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        public DateTime? ExpiryDate { get; set; }
        public DateTime? DateCashed { get; set; }

        [Required, StringLength(20)]
        public string Status { get; set; } = "Pending";

        public string? ProcessedById { get; set; }
        public string? Remarks { get; set; }

        // ✅ Only ONE FK
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }

}
