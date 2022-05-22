using Analysis.API.Models.Data;
using Analysis.API.Models.Local;
using Analysis.API.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Analysis.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StocksController(IStockRepository stockRepository) => _stockRepository = stockRepository;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _stockRepository.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Add(StockRequest request)
        {
            var result = await _stockRepository.AddAsync(new Stock
            {
                CompanyName = request.CompanyName,
                CompanyCode = request.CompanyCode,
                UnitPrice = request.UnitPrice,
                MinPrice = request.MinPrice,
                MaxPrice = request.MaxPrice,
                Category = request.Category,
                PercentageRisk = request.PercentageRisk
            });

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}