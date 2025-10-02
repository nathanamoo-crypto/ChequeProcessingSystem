using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChequeProcessingSystem.Models
{
    public class Cheque
    {
        [Key]
        public int ChequeId { get; set; }  // Primary Key

        [Required]
        public string ChequeNumber { get; set; } = string.Empty; // Cheque number

        [Required]
        public decimal Amount { get; set; } // Money amount

        [Required]
        public DateTime IssueDate { get; set; }

        public DateTime? ExpiryDate { get; set; }   // Optional expiry

        public DateTime? DateCashed { get; set; }   // When cashed

        [Required]
        public string Status { get; set; } = "Pending"; // Pending, Cleared, Bounced

        public string? ProcessedById { get; set; }  // User ID of staff who processed
        public string? Remarks { get; set; }        // Notes

        // Foreign Key to Account
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        // Audit fields
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
