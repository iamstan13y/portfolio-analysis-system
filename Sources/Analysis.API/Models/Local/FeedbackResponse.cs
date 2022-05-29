namespace Analysis.API.Models.Local
{
    public class FeedbackResponse
    {
        public int TotalRating { get; set; }
        public decimal AverageRating { get; set; }
        
        public FeedbackResponse(int totalRating, decimal averageRating)
        {
            TotalRating = totalRating;
            AverageRating = averageRating;
        }
    }
}