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
        /// Get vaccination card by card id
        /// </summary>
        [HttpGet("getAllotherVaccinvationByCardId", Name = "getOtherVaccinationsByCardId")]
        public async Task<ActionResult<IEnumerable<OtherVaccinationDetailsDTO>>> GetOtherVaccinationsByCardId([Required] int cardId)
        {
            return await _otherVaccinationService.GetOtherVaccinationsByCardId(cardId);
        }

        /// <summary>
        /// Add other vaccinvation info to card
        /// </summary>
        [HttpPost("create/vaccinationCardId", Name = "createOtherVaccinvationToCard")]
        public async Task<ActionResult<OtherVaccinationDetailsDTO>> CreateOtherVaccinvationToCard([Required] int cardI, OtherVaccinationDTO otherVaccinationDTO)
        {
            return await _otherVaccinationService.CreateOtherVaccinvationToCard(cardI, otherVaccinationDTO);
        }

        /// <summary>
        /// Update other vaccinvation info to card bi vaccination id
        /// </summary>
        [HttpPut("update/otherVaccinationId", Name = "updateOtherVaccinvationToCard")]
        public async Task<ActionResult<OtherVaccinationDetailsDTO>> UpdateOtherVaccinvationToCard([Required] int id, OtherVaccinationDTO otherVaccinationDTO)
        {
            return await _otherVaccinationService.UpdateOtherVaccinvationToCard(id, otherVaccinationDTO);
        }
    }
}
