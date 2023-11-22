using backend.ModelsDTO;
using backend.Services.AgeGroups;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AgeGroupsController : ControllerBase
    {
        private readonly IAgeGroupService _ageGroupService;

        public AgeGroupsController(IAgeGroupService ageGroupService)
        {
            _ageGroupService = ageGroupService;
        }

        /// <summary>
        /// Get age groups list
        /// </summary>
        [Authorize]
        [HttpGet(Name = "getAgeGroups")]
        public async Task<ActionResult<IEnumerable<AgeGroupsDTO>>> GetAgeGroups()
        {
            return await _ageGroupService.GetAgeGroups();
        }
    }
}
