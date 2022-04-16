using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.API.Models
{
    public class Institution
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string? InsitutionName { get; set; }
        public string? Address { get; set; }
        public DateTime DateCreated { get; set; }
        [ForeignKey("AccountId")]
        public Account? Account { get; set; }
    }
}