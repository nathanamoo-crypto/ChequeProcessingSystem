using Microsoft.AspNetCore.Mvc;
using ChequeProcessingSystem.Data;
using System.Linq;

namespace ChequeProcessingSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Report/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Report/Daily
        public IActionResult Daily()
        {
            var today = System.DateTime.Today;
            var dailyCheques = _context.Cheques
                .Where(c => c.IssueDate.Date == today) // changed from DateIssued to IssueDate
                .ToList();
            return View(dailyCheques);
        }

        // GET: /Report/Rejected
        public IActionResult Rejected()
        {
            var rejectedCheques = _context.Cheques
                .Where(c => c.Status == "Rejected") // Ensure Status exists in your Cheque model
                .ToList();
            return View(rejectedCheques);
        }
    }
}
