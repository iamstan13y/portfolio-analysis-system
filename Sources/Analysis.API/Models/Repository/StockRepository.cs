using Analysis.API.Enums;
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

        public async Task<Result<Stock>> AddAsync(Stock stock)
        {
            try
            {
                await _context.AddAsync(stock);
                await _context.SaveChangesAsync();

                return new Result<Stock>(stock);
            }
            catch (Exception ex)
            {
                return new Result<Stock>(false, new List<string> { ex.ToString() });
            }
        }

        public async Task<Result<IEnumerable<Stock>>> GetAllAsync()
        {
            var stocks = await _context.Stocks!.ToListAsync();
            return new Result<IEnumerable<Stock>>(stocks);
        }

        public async Task<Result<IEnumerable<Stock>>> GetByCategoryIdAndProfileAsync(int categoryId, ProfileType profileType)
        {
            var stocks = (await GetByCategoryIdAsync(categoryId)).Data;

            switch (profileType)
            {
                case ProfileType.Conservative:
                    stocks = stocks!.Where(stock => stock.PercentageRisk >= 0 && stock.PercentageRisk < 20).ToList();
                    break;
                case ProfileType.Moderate:
                    stocks = stocks!.Where(stock => stock.PercentageRisk >= 20 && stock.PercentageRisk < 30).ToList();
                    break;
                case ProfileType.Aggressive:
                    stocks = stocks!.Where(stock => stock.PercentageRisk >= 30).ToList();
                    break;
            }

            return new Result<IEnumerable<Stock>>(stocks!);
        }

        public async Task<Result<IEnumerable<Stock>>> GetByCategoryIdAsync(int categoryId)
        {
            var stocks = await _context.Stocks!.Where(x => (int)x.Category == categoryId).ToListAsync();

            return new Result<IEnumerable<Stock>>(stocks);
        }

        public Task<Result<Stock>> UpdateAsync(Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}