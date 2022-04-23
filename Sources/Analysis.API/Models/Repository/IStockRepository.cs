using Analysis.API.Models.Data;
using ModelLibrary;

namespace Analysis.API.Models.Repository
{
    public interface IStockRepository
    {
        Task<Result<IEnumerable<Stock>>> GetAllAsync();
        Task<Result<Stock>> AddAsync(Stock stock);
        Task<Result<Stock>> UpdateAsync(Stock stock);
    }
}