using Analysis.API.Models.Data;
using Analysis.API.Models.Local;
using ModelLibrary;

namespace Analysis.API.Services
{
    public interface IAllocationService
    {
        Task<Result<Allocation>> CalculateAllocationAsync(AllocationRequest request);
    }
}