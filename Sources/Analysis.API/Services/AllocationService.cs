using Analysis.API.Enums;
using Analysis.API.Models.Data;
using Analysis.API.Models.Local;
using Analysis.API.Models.Repository;
using ModelLibrary;

namespace Analysis.API.Services
{
    public class AllocationService : IAllocationService
    {
        private readonly IStockRepository _stockRepository;
        private readonly Random _random;

        public AllocationService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
            _random = new Random();
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

            var stocks = (await _stockRepository.GetAllAsync()).Data!.ToList();

            for (int i = 0; i < allocation.Period; i++)
            {
                stocks.ForEach(stock => CalculateYearReturn(stock, allocation));
            }

            return new Result<Allocation>(allocation);
        }

        public Return CalculateYearReturn(Stock stock, Allocation allocation)
        {
            var returns = new Return();
            var shares = _random.Next((int)(allocation.StartingAmount / stock.MaxPrice), (int)(allocation.StartingAmount / stock.MinPrice));
            var stockAllocation = (stock.PercentAllocation / 100) * shares;

            switch (allocation.ProfileType)
            {
                case ProfileType.Conservative:
                    if (stockAllocation > (allocation.StartingAmount / stock.UnitPrice))
                    {
                        returns.CumulatedReturn = allocation.Returns!.ToList()!.LastOrDefault()!.CumulatedReturn + stockAllocation;
                    }
                    else
                    {
                        returns.CumulatedReturn = allocation.Returns!.ToList()!.LastOrDefault()!.CumulatedReturn - stockAllocation;

                    }
                    break;
                default:
                    break;
            }
            return returns;
        }
    }
}