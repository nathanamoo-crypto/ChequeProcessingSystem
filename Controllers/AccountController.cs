using Microsoft.AspNetCore.Mvc;
using ChequeProcessingSystem.Data;
using ChequeProcessingSystem.Models;
using System.Linq;

namespace ChequeProcessingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/
        public IActionResult Index()
        {
            var accounts = _context.Accounts.ToList();
            return View(accounts);
        }

        // GET: /Account/Details/5
        public IActionResult Details(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null) return NotFound();
            return View(account);
        }

        // GET: /Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: /Account/Edit/5
        public IActionResult Edit(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null) return NotFound();
            return View(account);
        }

        // POST: /Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Update(account);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: /Account/Delete/5
        public IActionResult Delete(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null) return NotFound();
            return View(account);
        }

        // POST: /Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null) return NotFound();

            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
