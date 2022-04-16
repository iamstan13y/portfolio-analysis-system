using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Models;
using UserManagement.API.Models.Data;
using UserManagement.API.Models.Repository;

namespace UserManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        [HttpPost("individual/create-profile")]
        public async Task<IActionResult> Add(IndividualProfileRequest request)
        {
            var result = await _userProfileRepository.CreateIndividualAsync(new Individual
            {
                AccountId = request.AccountId,
                Address = request.Address,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                DateCreated = DateTime.Now
            });

            if (result.Success == false) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("institution/create-profile")]
        public async Task<IActionResult> Add(InstitutionProfileRequest request)
        {
            var result = await _userProfileRepository.CreateInstitutionAsync(new Institution
            {
                AccountId = request.AccountId,
                Address = request.Address,
                InsitutionName = request.InstitutionName,
                DateCreated= DateTime.Now
            });

            if (result.Success == false) return BadRequest(result);

            return Ok(result);
        }
    }
}