using ModelLibrary.Enums;
using UserManagement.API.Enums;

namespace UserManagement.API.Models.Data
{
    public class AccountRequest
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public AccountType AccountType { get; set; }
    }
}