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
    }
}
