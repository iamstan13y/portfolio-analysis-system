namespace UserManagement.API.Models.Data
{
    public class IndividualProfileRequest
    {
        public int AccountId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}