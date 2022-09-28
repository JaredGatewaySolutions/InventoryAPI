using InventoryAPI.Models;

namespace InventoryAPI.Services.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailMessage message);
    }
}
