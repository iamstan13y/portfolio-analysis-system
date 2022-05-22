using Analysis.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace Analysis.API.Models.Data
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyCode { get; set; }
        public double UnitPrice { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public StockCategory Category { get; set; }
        public double PercentageRisk { get; set; }
    }
}