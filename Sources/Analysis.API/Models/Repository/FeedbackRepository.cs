using Analysis.API.Models.Data;
using Analysis.API.Models.Local;
using ModelLibrary;

namespace Analysis.API.Models.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public Task<Result<Feedback>> AddAsync(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public Task<Result<FeedbackResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}