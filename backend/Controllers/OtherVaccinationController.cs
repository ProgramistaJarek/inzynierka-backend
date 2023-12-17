using backend.ModelsDTO;
using backend.Services.OtherVaccinationService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class OtherVaccinationController : ControllerBase
    {
        private readonly IOtherVaccinationService _otherVaccinationService;

        public OtherVaccinationController(IOtherVaccinationService otherVaccinationService)
        {
            _otherVaccinationService = otherVaccinationService;
        }

        /// <summary>
        /// Get other vaccination by id
        /// </summary>
        /// <param name="vaccinationId"></param>
        /// <returns>Object of the other vaccination</returns>
        [HttpGet("getVaccinationInfo", Name = "GetOtherVaccination")]
        public async Task<ActionResult<OtherVaccinationCreateDTO>> GetOtherVaccination([Required] int vaccinationId)
        {
            return await _otherVaccinationService.GetOtherVaccination(vaccinationId);
        }

        /// <summary>
        /// Get vaccination card by card id
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns>List of the other vaccinations of the vaccination card</returns>
        [HttpGet("getAllotherVaccinvationByCardId", Name = "getOtherVaccinationsByCardId")]
        public async Task<ActionResult<IEnumerable<OtherVaccinationDTO>>> GetOtherVaccinationsByCardId([Required] int cardId)
        {
            return await _otherVaccinationService.GetOtherVaccinationsByCardId(cardId);
        }

        /// <summary>
        /// Add other vaccinvation info to card
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="otherVaccinationDTO"></param>
        /// <returns>Newly created other vaccination</returns>
        [HttpPost("create/vaccinationCardId", Name = "createOtherVaccinvationToCard")]
        public async Task<ActionResult<OtherVaccinationDTO>> CreateOtherVaccinvationToCard([Required] int cardId, OtherVaccinationCreateDTO otherVaccinationDTO)
        {
            return await _otherVaccinationService.CreateOtherVaccinvationToCard(cardId, otherVaccinationDTO);
        }

        /// <summary>
        /// Update other vaccinvation info to card by vaccination id
        /// </summary>
        /// <param name="vaccinationId"></param>
        /// <param name="otherVaccinationDTO"></param>
        /// <returns>Updated other vaccination</returns>
        [HttpPut("update/otherVaccinationId", Name = "updateOtherVaccinvationToCard")]
        public async Task<ActionResult<OtherVaccinationDTO>> UpdateOtherVaccinvationToCard([Required] int vaccinationId, OtherVaccinationCreateDTO otherVaccinationDTO)
        {
            return await _otherVaccinationService.UpdateOtherVaccinvationToCard(vaccinationId, otherVaccinationDTO);
        }
    }
}
