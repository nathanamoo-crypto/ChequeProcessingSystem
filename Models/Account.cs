using ChequeProcessingSystem.Models;

public class Account
{
    public int Id { get; set; }

    public string AccountNumber { get; set; } = string.Empty;

    public string HolderName { get; set; } = string.Empty; // <-- RENAME from AccountName

    public decimal Balance { get; set; }

    public string AccountType { get; set; } = string.Empty;

    // Navigation: An Account can have many Cheques
    public ICollection<Cheque> Cheques { get; set; } = new List<Cheque>();
}
