<<<<<<< HEAD
﻿using System;
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
=======
﻿public class Cheque
{
    public int ChequeId { get; set; }
>>>>>>> working-main

    public string ChequeNumber { get; set; } = string.Empty;
    public double Amount { get; set; }

    public DateTime IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }   // <-- NEW field
    public DateTime? DateCashed { get; set; }

    public string Status { get; set; } = "Pending";
    public string? ProcessedById { get; set; }
    public string? Remarks { get; set; }

<<<<<<< HEAD
        // Optional: audit fields
        public DateTime CreatedAt { get; set; } = DateTime.Now;  // Auto-set creation timestamp
        public DateTime? UpdatedAt { get; set; }                 // Track updates
>>>>>>> aeeaeea92f0f65fe4e6e41d8563c1d30e9a59a13
    }
=======
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
>>>>>>> working-main
}
