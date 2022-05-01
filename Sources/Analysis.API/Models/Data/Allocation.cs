using Analysis.API.Enums;
using ModelLibrary.Enums;

namespace Analysis.API.Models.Data
{
    public class Allocation
    {
        public AccountType AccountType { get; set; }
        public ProfileType ProfileType { get; set; }
        public double StartingAmount { get; set; }
        public int Period { get; set; }
        public List<Return>? Returns { get; set; }
    }
}