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
                .Where(c => c.DateIssued.Date == today)
                .ToList();
            return View(dailyCheques);
        }

        // GET: /Report/Rejected
        public IActionResult Rejected()
        {
            var rejectedCheques = _context.Cheques
                .Where(c => c.Status == "Rejected")
                .ToList();
            return View(rejectedCheques);
        }
    }
}
