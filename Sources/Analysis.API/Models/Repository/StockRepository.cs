using Analysis.API.Models.Data;
using ModelLibrary;

namespace Analysis.API.Models.Repository
{
    public class StockRepository : IStockRepository
    {
        public Task<Result<Stock>> AddAsync(Stock stock)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Stock>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Stock>> UpdateAsync(Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}