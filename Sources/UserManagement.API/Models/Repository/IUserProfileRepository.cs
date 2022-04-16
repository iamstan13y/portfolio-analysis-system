using ModelLibrary;

namespace UserManagement.API.Models.Repository
{
    public interface IUserProfileRepository
    {
        Task<Result<Individual>> CreateIndividualAsync(Individual individual);
        Task<Result<Institution>> CreateInstitutionAsync(Institution institution);
    }
}