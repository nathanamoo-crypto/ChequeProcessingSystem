using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ChequeProcessingSystem.Models;
using System.Threading.Tasks;

namespace ChequeProcessingSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: /User/
        public IActionResult Index()
        {
            var users = _userManager.Users;
            return View(users);
        }

        // GET: /User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUser user, string password)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    // Assign default role (e.g., Teller)
                    await _userManager.AddToRoleAsync(user, "Teller");
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }
    }
}
