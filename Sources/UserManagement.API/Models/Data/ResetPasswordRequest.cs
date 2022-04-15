namespace UserManagement.API.Models.Data
{
    public class ResetPasswordRequest
    {
        public string? UserEmail { get; set; }
        public string? VerificationCode { get; set; }
        public string? NewPassword { get; set; }
    }
}
