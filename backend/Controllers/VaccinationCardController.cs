using backend.ModelsDTO;
using backend.Services.VaccinationCardService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class VaccinationCardController : ControllerBase
    {
        private readonly IVaccinationCardService _vaccinationCardService;

        public VaccinationCardController(IVaccinationCardService vaccinationCardService)
        {
            _vaccinationCardService = vaccinationCardService;
        }

        /// <summary>
        /// Get vaccination card by card id
        /// </summary>
        [HttpGet("vaccinationCardById", Name = "getVaccinationCard")]
        public async Task<ActionResult<VaccinationCardDTO>> GetVaccinvationCard([Required] int id)
        {
            return await _vaccinationCardService.GetVaccinationCard(id);
        }

        /// <summary>
        /// Get vaccination card by patient id
        /// </summary>
        [HttpGet("vaccinationCardByPatientId", Name = "getVaccinationCardByPatient")]
        public async Task<ActionResult<VaccinationCardDTO>> GetVaccinvationCardByPatient([Required] int id)
        {
            return await _vaccinationCardService.GetVaccinationCardByPatientId(id);
        }

        /// <summary>
        /// Add new vaccination information to vaccination card
        /// </summary>
        [HttpPost("addVaccinationInfoToCard", Name = "addVaccinationInfoToCard")]
        public async Task<ActionResult<VaccinationCardDTO>> AddVaccinationToCard([Required] int id, [FromBody] VaccinationInfoCreateDTO vaccinationInfoDTO)
        {
            return await _vaccinationCardService.AddVaccinationToCard(id, vaccinationInfoDTO);
        }

        /// <summary>
        /// Update existing vaccinvation card
        /// </summary>
        [HttpPut("update", Name = "updateVaccinationCard")]
        public async Task<ActionResult<VaccinationCardDTO>> UpdateVaccinationCard([Required] int id, [FromBody] VaccinationCardDTO vaccinationCardDTO)
        {
            return await _vaccinationCardService.UpdateVaccinationCard(id, vaccinationCardDTO);
        }
    }
}
