namespace ChequeProcessingSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string email, string password);
        Task<bool> LogoutAsync(string userId);
    }
}
