namespace Cheque_Processing_System.Services.Interfaces
{
    public interface INotificationService
    {
        Task SendEmailAsync(string to, string subject, string message);
        Task SendSmsAsync(string number, string message);
    }
}
