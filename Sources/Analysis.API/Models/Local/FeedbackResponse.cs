namespace Analysis.API.Models.Local
{
    public class FeedbackResponse
    {
        public int TotalRating { get; set; }
        public double AverageRating { get; set; }
        
        public FeedbackResponse(int totalRating, int averageRating)
        {
            TotalRating = totalRating;
            AverageRating = averageRating;
        }
    }
}