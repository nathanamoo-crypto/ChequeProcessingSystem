using ChequeProcessingSystem.Services.Interfaces;

namespace ChequeProcessingSystem.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        public async Task SendEmailAsync(string to, string subject, string message)
        {
            // Replace with real email service later
            await Task.Run(() => Console.WriteLine($"Email to {to}: {subject} - {message}"));
        }

        public async Task SendSmsAsync(string number, string message)
        {
            // Replace with real SMS gateway later
            await Task.Run(() => Console.WriteLine($"SMS to {number}: {message}"));
        }
    }
}
