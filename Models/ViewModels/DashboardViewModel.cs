using System.Collections.Generic;
using ChequeProcessingSystem.Models;

namespace ChequeProcessingSystem.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalCheques { get; set; }
        public int TotalAccounts { get; set; }
        public int ClearedCheques { get; set; }
        public int BouncedCheques { get; set; }
        public int PendingCheques { get; set; }   // ✅ Add this

        public List<Cheque> Cheques { get; set; } = new();
    }
}
