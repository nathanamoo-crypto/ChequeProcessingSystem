using ChequeProcessingSystem.Models;
using ChequeProcessingSystem.Services.Interfaces;

namespace ChequeProcessingSystem.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly List<ApplicationUser> _mockDb = new(); // Replace with EF later

        public async Task<ApplicationUser> RegisterUserAsync(ApplicationUser user, string password)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("Email is required");

            if (password.Length < 6)
                throw new ArgumentException("Password must be at least 6 characters");

            user.Role ??= "Teller";
            _mockDb.Add(user);

            return await Task.FromResult(user);
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
        {
            return await Task.FromResult(_mockDb.FirstOrDefault(u => u.Id == userId));
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await Task.FromResult(_mockDb);
        }

        public async Task<bool> AssignRoleAsync(string userId, string role)
        {
            var user = _mockDb.FirstOrDefault(u => u.Id == userId);
            if (user == null) return false;

            user.Role = role;
            return await Task.FromResult(true);
        }
    }
}
