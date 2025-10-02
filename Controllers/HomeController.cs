using ChequeProcessingSystem.Data;
using ChequeProcessingSystem.Models;
using ChequeProcessingSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ChequeProcessingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var cheques = _context.Cheques
                                  .Include(c => c.Account)
                                  .ToList();

            var model = new DashboardViewModel
            {
                TotalCheques = cheques.Count,
                ClearedCheques = cheques.Count(c => c.Status == "Cleared"),
                BouncedCheques = cheques.Count(c => c.Status == "Bounced"),
                PendingCheques = cheques.Count(c => c.Status == "Pending"),
                Cheques = cheques
            };

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
