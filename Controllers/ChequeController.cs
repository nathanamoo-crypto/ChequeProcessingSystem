using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChequeProcessingSystem.Data;
using ChequeProcessingSystem.Models;

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
            var cheques = _context.Cheques
                .Include(c => c.Account) // include related Account info
                .ToList();
            return View(cheques);
        }

        // GET: /Cheque/Details/5
        public IActionResult Details(int id)
        {
            var cheque = _context.Cheques
                .Include(c => c.Account)
                .FirstOrDefault(c => c.ChequeId == id);

            if (cheque == null) return NotFound();
            return View(cheque);
        }

        // GET: /Cheque/Create
        public IActionResult Create()
        {
            ViewBag.Accounts = _context.Accounts.ToList(); // dropdown for accounts
            return View();
        }

        // POST: /Cheque/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cheque cheque)
        {
            if (ModelState.IsValid)
            {
                cheque.Status = "Pending";       // default
                cheque.CreatedAt = DateTime.Now; // audit field

                _context.Cheques.Add(cheque);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Accounts = _context.Accounts.ToList();
            return View(cheque);
        }

        // GET: /Cheque/Edit/5
        public IActionResult Edit(int id)
        {
            var cheque = _context.Cheques.Find(id);
            if (cheque == null) return NotFound();

            ViewBag.Accounts = _context.Accounts.ToList();
            return View(cheque);
        }

        // POST: /Cheque/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cheque cheque)
        {
            if (ModelState.IsValid)
            {
                cheque.UpdatedAt = DateTime.Now;
                _context.Cheques.Update(cheque);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Accounts = _context.Accounts.ToList();
            return View(cheque);
        }

        // GET: /Cheque/Verify/5
        public IActionResult Verify(int id)
        {
            var cheque = _context.Cheques
                .Include(c => c.Account)
                .FirstOrDefault(c => c.ChequeId == id);

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

            cheque.Status = approve ? "Cleared" : "Bounced";
            cheque.UpdatedAt = DateTime.Now;

            _context.Cheques.Update(cheque);
            _context.SaveChanges();

            // 🔹 TODO: Add AuditLog entry here (who approved, when, remarks, etc.)

            return RedirectToAction(nameof(Index));
        }

        // GET: /Cheque/Delete/5
        public IActionResult Delete(int id)
        {
            var cheque = _context.Cheques.Find(id);
            if (cheque == null) return NotFound();
            return View(cheque);
        }

        // POST: /Cheque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cheque = _context.Cheques.Find(id);
            if (cheque == null) return NotFound();

            _context.Cheques.Remove(cheque);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
