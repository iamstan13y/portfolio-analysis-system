using Microsoft.EntityFrameworkCore;
using ModelLibrary;
using UserManagement.API.Enums;
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

            if (await ActivateAccount(individual.AccountId) == false)
                return new Result<Individual>(false, new List<string> { "Failed to save details." });

            return new Result<Individual>(individual);
        }

        public async Task<Result<Institution>> CreateInstitutionAsync(Institution institution)
        {
            await _context.Institutions!.AddAsync(institution);

            if (await ActivateAccount(institution.AccountId) == false)
                return new Result<Institution>(false, new List<string> { "Failed to save details." });

            return new Result<Institution>(institution);
        }

        public async Task<bool> ActivateAccount(int accountId)
        {
            var account = await _context.Accounts!.Where(k => k.Id == accountId).FirstOrDefaultAsync();
            if (account == null) return false;

            account.Status = Status.Active;
            _context.Accounts!.Update(account);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}