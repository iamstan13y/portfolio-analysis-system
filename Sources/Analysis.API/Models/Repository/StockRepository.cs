using Analysis.API.Models.Data;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;

namespace Analysis.API.Models.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;

        public StockRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Result<Stock>> AddAsync(Stock stock)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<Stock>>> GetAllAsync()
        {
            var stocks = await _context.Stocks!.ToListAsync();
            return new Result<IEnumerable<Stock>>(stocks);
        }

        public Task<Result<Stock>> UpdateAsync(Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}