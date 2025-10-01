using ChequeProcessingSystem.Models;

namespace ChequeProcessingSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> RegisterUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser?> GetUserByIdAsync(string userId);
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<bool> AssignRoleAsync(string userId, string role);
    }
}
