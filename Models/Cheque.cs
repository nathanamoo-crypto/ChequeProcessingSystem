using System;

namespace ChequeProcessingSystem.Models
{
    public class Cheque
    {
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
    }
}
