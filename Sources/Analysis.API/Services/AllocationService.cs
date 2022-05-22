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

            allocation.Returns?.AddRange(new List<Return>()
            {
                new Return
                {
                    CumulatedReturn = 0,
                    Year = 0
                },
                new Return
                {
                    Year = currentYear,
                    CumulatedReturn = (decimal)allocation.StartingAmount
                }
            });

            for (int i = 0; i < allocation.Period; i++)
            {
                decimal cumulated = 0;
                foreach (var stock in stocks)
                {
                    cumulated += CalculateYearReturn(stock, allocation, currentYear).CumulatedReturn;

                }
                currentYear++;

                allocation.Returns?.Add(new Return
                {
                    Year = currentYear,
                    CumulatedReturn = cumulated + allocation.Returns.LastOrDefault()!.CumulatedReturn
                }); ;
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
            //var percentAllocation = (stock.PercentAllocation / 100) * allocation.StartingAmount;
            //var shares = percentAllocation / predictedCost;
            //var unitShares = percentAllocation / stock.UnitPrice;

            //var returnShare = shares >= unitShares ? (shares - unitShares) * predictedCost : (unitShares - shares) * predictedCost;

            //switch (allocation.ProfileType)
            //{
            //    case ProfileType.Conservative:
            //        returnShare *= 1.5;
            //        break;
            //    case ProfileType.Moderate:
            //        returnShare *= 2;
            //        break;
            //    case ProfileType.Aggressive:
            //        returnShare *= 3;
            //        break;
            //}

            //returns.CumulatedReturn = Math.Round((decimal)returnShare, 2);
            return returns;
        }
    }
}