using ModelLibrary;
using UserManagement.API.Models.Data;

namespace UserManagement.API.Models.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Individual>> CreateIndividualAsync(Individual individual)
        {
            await _context.Individuals!.AddAsync(individual);
            await _context.SaveChangesAsync();

            return new Result<Individual>(individual);
        }

        public async Task<Result<Institution>> CreateInstitutionAsync(Institution institution)
        {
            await _context.Institutions!.AddAsync(institution);
            await _context.SaveChangesAsync();

            return new Result<Institution>(institution);
        }
    }
}