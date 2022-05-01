using Analysis.API.Models.Local;
using Analysis.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Analysis.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AllocationsController : ControllerBase
    {
        private readonly IAllocationService _allocationService;

        public AllocationsController(IAllocationService allocationService)
        {
            _allocationService = allocationService;
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(AllocationRequest request)
        {
            var result = await _allocationService.CalculateAllocationAsync(request);
            return Ok(result);
        }
    }
}