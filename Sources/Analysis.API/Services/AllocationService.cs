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
                    CumulatedReturn = cumulated + allocation.Returns.LastOrDefault().CumulatedReturn
                });;
            }

            return new Result<Allocation>(allocation);
        }

        private Return CalculateYearReturn(Stock stock, Allocation allocation, int currentYear)
        {
            var returns = new Return
            {
                Year = currentYear
            };

            var inititalCost = _random.NextDouble();
            var predictedCost = inititalCost <= stock.UnitPrice ? inititalCost += stock.MinPrice : stock.MaxPrice - inititalCost;
            var percentAllocation = (stock.PercentAllocation / 100) * allocation.StartingAmount;
            var shares = percentAllocation / predictedCost;
            var unitShares = percentAllocation / stock.UnitPrice;

            switch (allocation.ProfileType)
            {
                case ProfileType.Conservative:
                case ProfileType.Moderate:
                    if (shares >= (percentAllocation / stock.UnitPrice))
                    {
                        var profit = (shares - unitShares) * predictedCost;
                        returns.CumulatedReturn = profit;
                    }
                    else
                    {
                        var loss = (unitShares - shares) * predictedCost;
                        returns.CumulatedReturn = loss;
                    }
                    break;
                default:
                    if (shares >= (percentAllocation / stock.UnitPrice))
                    {
                        var profit = (shares - unitShares) * predictedCost;
                        returns.CumulatedReturn = profit;
                    }
                    else
                    {
                        var loss = (shares - unitShares) * predictedCost;
                        returns.CumulatedReturn = loss;
                    }
                    break;
            }
            return returns;
        }
    }
}