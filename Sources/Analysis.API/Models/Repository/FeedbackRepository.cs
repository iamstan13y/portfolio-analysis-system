using Analysis.API.Models.Data;
using Analysis.API.Models.Local;
using ModelLibrary;

namespace Analysis.API.Models.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _context;

        public FeedbackRepository(AppDbContext context) => _context = context;
      
        public async Task<Result<Feedback>> AddAsync(Feedback feedback)
        {
            await _context.Feedback!.AddAsync(feedback);
            await _context.SaveChangesAsync();

            return new Result<Feedback>(feedback);
        }

        public Task<Result<FeedbackResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}