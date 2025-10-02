using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChequeProcessingSystem.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }  // Primary Key

        [Required]
        [StringLength(100)]
        public string HolderName { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string AccountNumber { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]  // ✅ Ensures proper precision in SQL
        public decimal Balance { get; set; }

        // Navigation property → one Account can have many Cheques
        public ICollection<Cheque> Cheques { get; set; } = new List<Cheque>();
    }
}
