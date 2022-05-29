using Analysis.API.Models.Data;
using Analysis.API.Models.Local;
using ModelLibrary;

namespace Analysis.API.Models.Repository
{
    public interface IFeedbackRepository
    {
        Task<Result<Feedback>> AddAsync(Feedback feedback);
        Task<Result<FeedbackResponse>> GetAllAsync();
    }
}