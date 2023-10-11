using backend.ModelsDTO;
using backend.Services.VaccinationCardService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpGet("{id}", Name = "getVaccinationCard")]
        public async Task<ActionResult<VaccinationCardDTO>> GetVaccinvationCard(int id)
        {
            return await _vaccinationCardService.GetVaccinationCard(id);
        }

        /// <summary>
        /// Get vaccination card by patient id
        /// </summary>
        [HttpGet("patient/{id}", Name = "getVaccinationCardByPatient")]
        public async Task<ActionResult<VaccinationCardDTO>> GetVaccinvationCardByPatient(int id)
        {
            return await _vaccinationCardService.GetVaccinationCardByPatientId(id);
        }

        /// <summary>
        /// Add new vaccination information to vaccination card
        /// </summary>
        [HttpPost("{id}", Name = "addVaccinationToCard")]
        public async Task<ActionResult<VaccinationCardDTO>> AddVaccinationToCard(int id, VaccinationInfoCreateDTO vaccinationInfoDTO)
        {
            return await _vaccinationCardService.AddVaccinationToCard(id, vaccinationInfoDTO);
        }

        /// <summary>
        /// Update existing vaccinvation card
        /// </summary>
        [HttpPut("{id}", Name = "updateVaccinationCard")]
        public async Task<ActionResult<VaccinationCardDTO>> UpdateVaccinationCard(int id, VaccinationCardDTO vaccinationCardDTO)
        {
            return await _vaccinationCardService.UpdateVaccinationCard(id, vaccinationCardDTO);
        }
    }
}
