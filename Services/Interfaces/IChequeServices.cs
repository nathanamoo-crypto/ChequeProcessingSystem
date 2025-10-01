using Cheque_Processing_System.Models;

namespace Cheque_Processing_System.Services.Interfaces
{
    public interface IChequeService
    {
        Task<Cheque> SubmitChequeAsync(Cheque cheque);
        Task<bool> ApproveChequeAsync(int chequeId, string managerId);
        Task<bool> RejectChequeAsync(int chequeId, string managerId, string reason);
        Task<IEnumerable<Cheque>> GetPendingChequesAsync();
        Task<Cheque?> GetChequeByIdAsync(int chequeId);
    }
}
