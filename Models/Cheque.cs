public class Cheque
{
    public int ChequeId { get; set; }

    public string ChequeNumber { get; set; } = string.Empty;
    public double Amount { get; set; }

    public DateTime IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }   // <-- NEW field
    public DateTime? DateCashed { get; set; }

    public string Status { get; set; } = "Pending";
    public string? ProcessedById { get; set; }
    public string? Remarks { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
