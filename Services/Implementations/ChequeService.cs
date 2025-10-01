using ChequeProcessingSystem.Models;
using Cheque_Processing_System.Services.Interfaces;

namespace Cheque_Processing_System.Services.Implementations
{
    public class ChequeService : IChequeService
    {
        private readonly List<Cheque> _mockDb = new(); // Replace later with EF DbContext

        public async Task<Cheque> SubmitChequeAsync(Cheque cheque)
        {
            if (cheque.Amount <= 0)
                throw new ArgumentException("Cheque amount must be greater than zero");

            cheque.Status = "Pending";
            cheque.IssueDate = DateTime.UtcNow;

            _mockDb.Add(cheque);
            return await Task.FromResult(cheque);
        }

        public async Task<bool> ApproveChequeAsync(int chequeId, string managerId)
        {
            var cheque = _mockDb.FirstOrDefault(c => c.ChequeId == chequeId);
            if (cheque == null) return false;

            if (cheque.Amount > 10000)
                throw new InvalidOperationException("High-value cheques require dual approval");

            cheque.Status = "Approved";
            cheque.ProcessedById = managerId;
            return await Task.FromResult(true);
        }

        public async Task<bool> RejectChequeAsync(int chequeId, string managerId, string reason)
        {
            var cheque = _mockDb.FirstOrDefault(c => c.ChequeId == chequeId);
            if (cheque == null) return false;

            cheque.Status = "Rejected";
            cheque.ProcessedById = managerId;
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Cheque>> GetPendingChequesAsync()
        {
            return await Task.FromResult(_mockDb.Where(c => c.Status == "Pending"));
        }

        public async Task<Cheque?> GetChequeByIdAsync(int chequeId)
        {
            return await Task.FromResult(_mockDb.FirstOrDefault(c => c.ChequeId == chequeId));
        }
    }
}
