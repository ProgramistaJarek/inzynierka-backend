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
        /// <param name="cardId"></param>
        /// <returns>Object of the vaccination card with information</returns>
        [HttpGet("vaccinationCardById", Name = "getVaccinationCard")]
        public async Task<ActionResult<VaccinationCardDTO>> GetVaccinvationCard([Required] int cardId)
        {
            return await _vaccinationCardService.GetVaccinationCard(cardId);
        }

        /// <summary>
        /// Get vaccination card by patient id
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns>Object of the vaccination card with information</returns>
        [HttpGet("vaccinationCardByPatientId", Name = "getVaccinationCardByPatient")]
        public async Task<ActionResult<VaccinationCardDTO>> GetVaccinvationCardByPatient([Required] int patientId)
        {
            return await _vaccinationCardService.GetVaccinationCardByPatientId(patientId);
        }

        /// <summary>
        /// Update existing vaccinvation card
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="vaccinationCardDTO"></param>
        /// <returns>Object of the vaccination card with information</returns>
        [HttpPut("update", Name = "updateVaccinationCard")]
        public async Task<ActionResult<VaccinationCardDTO>> UpdateVaccinationCard([Required] int cardId, [FromBody] VaccinationCardCreateDTO vaccinationCardDTO)
        {
            return await _vaccinationCardService.UpdateVaccinationCard(cardId, vaccinationCardDTO);
        }
    }
}
