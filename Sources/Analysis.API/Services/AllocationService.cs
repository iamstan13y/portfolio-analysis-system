using Analysis.API.Models.Data;
using Analysis.API.Models.Local;
using Analysis.API.Models.Repository;
using ModelLibrary;

namespace Analysis.API.Services
{
    public class AllocationService : IAllocationService
    {
        private readonly IStockRepository _stockRepository;

        public AllocationService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<Result<Allocation>> CalculateAllocationAsync(AllocationRequest request)
        {
            var allocation = new Allocation
            {
                AccountType = request.AccountType,
                StartingAmount = request.StartingAmount,
                Period = request.Period,
                ProfileType = request.ProfileType
            };

            var stocks = (await _stockRepository.GetAllAsync()).Data;

            for (int i = 0; i < allocation.Period; i++)
            {
                //           var 
            }

            return null;
        }
    }
}