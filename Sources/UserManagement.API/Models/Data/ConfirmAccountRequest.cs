using System;

namespace UserManagement.API.Models.Data
{
    public class ConfirmAccountRequest
    {
        public string Email{ get; set; }
        public string ConfirmationCode { get; set; }
    }
}