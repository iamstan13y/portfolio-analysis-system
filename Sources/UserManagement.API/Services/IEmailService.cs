using ModelLibrary;
using UserManagement.API.Models.Data;

namespace UserManagement.API.Services
{
    public interface IEmailService
    {
        Task<Result<string>> SendEmailAsync(EmailRequest email);
    }
}
