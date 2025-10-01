using ChequeProcessingSystem.Services.Interfaces;

namespace ChequeProcessingSystem.Services.Implementations
{
    public class AuthService : IAuthService
    {
        public async Task<string> LoginAsync(string email, string password)
        {
            // Replace with Identity Framework logic
            if (email == "admin@bank.com" && password == "password123")
                return await Task.FromResult("FAKE_JWT_TOKEN");

            throw new UnauthorizedAccessException("Invalid credentials");
        }

        public async Task<bool> LogoutAsync(string userId)
        {
            // Handle session cleanup
            return await Task.FromResult(true);
        }
    }
}
