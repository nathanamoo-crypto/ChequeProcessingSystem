using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChequeProcessingSystem.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }  // Primary key

        [Required]
        [StringLength(100)]
        public string HolderName { get; set; } = string.Empty;  // ✅ Fixes "HolderName not found"

        [Required]
        [StringLength(20)]
        public string AccountNumber { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        // Navigation property → one Account can have many Cheques
        public ICollection<Cheque> Cheques { get; set; } = new List<Cheque>();
    }
}
