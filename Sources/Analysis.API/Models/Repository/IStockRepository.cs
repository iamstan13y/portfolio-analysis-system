using Analysis.API.Enums;
using Analysis.API.Models.Data;
using ModelLibrary;

namespace Analysis.API.Models.Repository
{
    public interface IStockRepository
    {
        Task<Result<IEnumerable<Stock>>> GetAllAsync();
        Task<Result<Stock>> AddAsync(Stock stock);
        Task<Result<Stock>> UpdateAsync(Stock stock);
        Task<Result<IEnumerable<Stock>>> GetByCategoryIdAsync(StockCategory categoryId);
        Task<Result<IEnumerable<Stock>>> GetByCategoryIdAndProfileAsync(StockCategory category, ProfileType profileType);
    }
}