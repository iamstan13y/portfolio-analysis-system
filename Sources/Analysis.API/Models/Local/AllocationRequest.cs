using Analysis.API.Enums;
using ModelLibrary.Enums;

namespace Analysis.API.Models.Local
{
    public class AllocationRequest
    {
        public AccountType AccountType { get; set; }
        public ProfileType ProfileType { get; set; }
        public double StartingAmount { get; set; }
        public int Period { get; set; }
    }
}