using System;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
=======
>>>>>>> aeeaeea92f0f65fe4e6e41d8563c1d30e9a59a13

namespace ChequeProcessingSystem.Models
{
    public class Cheque
    {
<<<<<<< HEAD
        [Key]
        public int ChequeId { get; set; }  // Primary Key

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public string Status { get; set; } = "Pending"; // Pending, Cleared, Bounced

        // Foreign Key to Account
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
=======
        // Primary key
        public int ChequeId { get; set; }

        // Cheque details
        public string ChequeNumber { get; set; } = string.Empty; // Required
        public double Amount { get; set; }                        // Required
        public DateTime IssueDate { get; set; }                   // When the cheque was issued
        public DateTime? DateCashed { get; set; }                 // Nullable: only set when cashed

        // Status tracking
        public string Status { get; set; } = "Pending";           // Pending, Cleared, Bounced
        public string? ProcessedById { get; set; }                // User ID of the person who processed the cheque
        public string? Remarks { get; set; }                      // Optional notes about the cheque

        // Foreign key relationship
        public int AccountId { get; set; }                        // Link to Account
        public Account Account { get; set; } = null!;            // Navigation property

        // Optional: audit fields
        public DateTime CreatedAt { get; set; } = DateTime.Now;  // Auto-set creation timestamp
        public DateTime? UpdatedAt { get; set; }                 // Track updates
>>>>>>> aeeaeea92f0f65fe4e6e41d8563c1d30e9a59a13
    }
}
