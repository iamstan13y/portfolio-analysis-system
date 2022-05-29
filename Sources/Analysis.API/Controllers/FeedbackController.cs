using Analysis.API.Models.Data;
using Analysis.API.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Analysis.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository) => _feedbackRepository = feedbackRepository;

        [HttpPost]
        public async Task<IActionResult> Post(int rating) => 
            Ok(await _feedbackRepository.AddAsync(new Feedback { Rating = rating}));
    }
}