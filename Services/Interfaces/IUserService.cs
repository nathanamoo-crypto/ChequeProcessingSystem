using Cheque_Processing_System.Models;

namespace Cheque_Processing_System.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> RegisterUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser?> GetUserByIdAsync(string userId);
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<bool> AssignRoleAsync(string userId, string role);
    }
}
