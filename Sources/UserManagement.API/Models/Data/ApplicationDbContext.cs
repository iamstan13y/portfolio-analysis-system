using Microsoft.EntityFrameworkCore;

namespace UserManagement.API.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Account>? Accounts { get; set; }
        public DbSet<GeneratedCode>? GeneratedCodes { get; set; }
    }
}
