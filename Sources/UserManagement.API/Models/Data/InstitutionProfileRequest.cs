namespace UserManagement.API.Models.Data
{
    public class InstitutionProfileRequest
    {
        public int AccountId { get; set; }
        public string? InstitutionName { get; set; }
        public string? Address { get; set; }
    }
}