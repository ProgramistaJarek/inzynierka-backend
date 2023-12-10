using backend.ModelsDTO;
using backend.Services.VaccinationType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class VaccinvationTypeController : ControllerBase
    {
        private readonly IVaccinationTypeService _vaccinationTypeService;

        public VaccinvationTypeController(IVaccinationTypeService vaccinationTypeService)
        {
            _vaccinationTypeService = vaccinationTypeService;
        }

        /// <summary>
        /// Get vaccination type list
        /// </summary>
        [Authorize]
        [HttpGet(Name = "getVaccinationTypes")]
        public async Task<ActionResult<IEnumerable<VaccinationTypeDTO>>> GetVaccinationTypes()
        {
            return await _vaccinationTypeService.GetVaccinationTypes();
        }
    }
}
