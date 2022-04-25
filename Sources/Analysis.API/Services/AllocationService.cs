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
                ProfileType = request.ProfileType,
                Returns = new List<Return>()
            };



            var stocks = (await _stockRepository.GetAllAsync()).Data!.ToList();
            var currentYear = DateTime.Now.Year;
            
            allocation.Returns?.Add(new Return
            {
                Year = currentYear,
                CumulatedReturn = allocation.StartingAmount
            });

            for (int i = 0; i < allocation.Period; i++)
            {
                double cumulated = 0;
                foreach (var stock in stocks)
                {
                   cumulated += CalculateYearReturn(stock, allocation, currentYear).CumulatedReturn;

                }
                currentYear++;

                allocation.Returns?.Add(new Return
                {
                    Year = currentYear,
                    CumulatedReturn = cumulated
                });
            }

            return new Result<Allocation>(allocation);
        }

        public Return CalculateYearReturn(Stock stock, Allocation allocation, int currentYear)
        {
            var returns = new Return
            {
                Year = currentYear
            };

            var shares = _random.Next((int)(allocation.StartingAmount / stock.MaxPrice), (int)(allocation.StartingAmount / stock.MinPrice));
            var predictedPrice = allocation.StartingAmount / shares;
            var stockAllocation = (stock.PercentAllocation / 100) * shares;
            var shareCost = stockAllocation * predictedPrice;
            switch (allocation.ProfileType)
            {
                case ProfileType.Conservative:
                case ProfileType.Moderate:
                    if (shareCost >= ((allocation.StartingAmount / stock.UnitPrice) * stock.PercentAllocation) * stock.UnitPrice)
                    {
                        returns.CumulatedReturn = (double)(allocation.Returns!.LastOrDefault()!.CumulatedReturn + shareCost);
                    }
                    else
                    {
                        returns.CumulatedReturn = allocation.Returns!.LastOrDefault()!.CumulatedReturn - shareCost;
                    }
                    break;
                default:
                    if (shareCost >= ((allocation.StartingAmount / stock.UnitPrice) * stock.PercentAllocation) * stock.UnitPrice)
                    {
                        returns.CumulatedReturn = allocation.Returns!.LastOrDefault()!.CumulatedReturn - shareCost;
                    }
                    else
                    {
                        returns.CumulatedReturn = allocation.Returns!.LastOrDefault()!.CumulatedReturn + shareCost;
                    }
                    break;
            }
            return returns;
        }
    }
}