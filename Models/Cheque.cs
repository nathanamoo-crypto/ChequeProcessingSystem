namespace ChequeProcessingSystem.Models
{
    public class Cheque
    {
        public int Id { get; set; }

        public string ChequeNumber { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime IssuedDate { get; set; }

        public DateTime? ClearedDate { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected, Cleared

        // Foreign Key to Account
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
