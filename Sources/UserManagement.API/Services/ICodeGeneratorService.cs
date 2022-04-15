using System.Threading.Tasks;

namespace UserManagement.API.Services
{
    public interface ICodeGeneratorService
    {
        Task<string> GenerateVerificationCode();
    }
}
