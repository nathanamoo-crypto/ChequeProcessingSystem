using Microsoft.AspNetCore.Mvc;
using ChequeProcessingSystem.Data;
using ChequeProcessingSystem.Models;
using System.Linq;

namespace ChequeProcessingSystem.Controllers
{
    public class ChequeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChequeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Cheque/
        public IActionResult Index()
        {
            var cheques = _context.Cheques.ToList();
            return View(cheques);
        }

        // GET: /Cheque/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Cheque/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cheque cheque)
        {
            if (ModelState.IsValid)
            {
                cheque.Status = "Pending"; // default
                _context.Cheques.Add(cheque);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cheque);
        }

        // GET: /Cheque/Details/5
        public IActionResult Details(int id)
        {
            var cheque = _context.Cheques.Find(id);
            if (cheque == null) return NotFound();
            return View(cheque);
        }

        // GET: /Cheque/Verify/5
        public IActionResult Verify(int id)
        {
            var cheque = _context.Cheques.Find(id);
            if (cheque == null) return NotFound();
            return View(cheque);
        }

        // POST: /Cheque/Verify/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Verify(int id, bool approve)
        {
            var cheque = _context.Cheques.Find(id);
            if (cheque == null) return NotFound();

            cheque.Status = approve ? "Approved" : "Rejected";
            _context.Cheques.Update(cheque);

            // Audit logging could go here

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
