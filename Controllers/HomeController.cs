using ChequeProcessingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChequeProcessingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ChequeContext _context;

        public HomeController(ILogger<HomeController> logger, ChequeContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Load cheques including Account (so HolderName isn’t null)
            var cheques = _context.Cheques
                                  .Include(c => c.Account)
                                  .ToList();

            return View(cheques);
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
