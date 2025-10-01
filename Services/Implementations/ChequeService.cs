using ChequeProcessingSystem.Data;
using ChequeProcessingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ChequeProcessingSystem.Services
{
    public class ChequeService : IChequeService
    {
        private readonly ApplicationDbContext _context;

        public ChequeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cheque> GetAllCheques()
        {
            return _context.Cheques.Include(c => c.Account).ToList();
        }

        public Cheque? GetChequeById(int id)
        {
            return _context.Cheques.Include(c => c.Account).FirstOrDefault(c => c.ChequeId == id);
        }

        public void AddCheque(Cheque cheque)
        {
            _context.Cheques.Add(cheque);
            _context.SaveChanges();
        }

        public void UpdateCheque(Cheque cheque)
        {
            _context.Cheques.Update(cheque);
            _context.SaveChanges();
        }

        public void DeleteCheque(int id)
        {
            var cheque = _context.Cheques.Find(id);
            if (cheque != null)
            {
                _context.Cheques.Remove(cheque);
                _context.SaveChanges();
            }
        }
    }
}
