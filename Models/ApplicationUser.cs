using Microsoft.AspNetCore.Identity;

namespace ChequeProcessingSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add custom fields for your bank users
        public string FullName { get; set; } = string.Empty;

        public string Role { get; set; } = "User"; // e.g., Teller, Manager, Admin
    }
}
