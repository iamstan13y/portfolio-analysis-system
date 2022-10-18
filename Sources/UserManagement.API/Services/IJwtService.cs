using UserManagement.API.Models;

namespace UserManagement.API.Services
{
    public interface IJwtService
    {
        Task<string> GenerateToken(Account account);
    }
}
