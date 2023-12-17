using backend.ModelsDTO;
using backend.Services.VaccinationInfoService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class VaccinationInfoController : ControllerBase
    {
        private readonly IVaccinationInfoService _vaccinationInfoService;

        public VaccinationInfoController(IVaccinationInfoService vaccinationInfoService)
        {
            _vaccinationInfoService = vaccinationInfoService;
        }

        /// <summary>
        /// Get vaccination info by id
        /// </summary>
        /// <param name="vaccinationId"></param>
        /// <returns>Vaccination info object</returns>
        [HttpGet("getVaccinationInfo", Name = "GetVaccinationInfo")]
        public async Task<ActionResult<VaccinationInfoCreateDTO>> GetVaccinationInfo([Required] int vaccinationId)
        {
            return await _vaccinationInfoService.GetVaccinationInfo(vaccinationId);
        }

        /// <summary>
        /// Get vaccination infos card by card id
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns>List of the vaccination infos to card</returns>
        [HttpGet("getAllVaccinvationInfosByCardId", Name = "GetVaccinationInfosByCardId")]
        public async Task<ActionResult<IEnumerable<VaccinationInfoDTO>>> GetVaccinationInfosByCardId([Required] int cardId)
        {
            return await _vaccinationInfoService.GetVaccinationInfosByCardId(cardId);
        }

        /// <summary>
        /// Create vaccination info to vaccination card
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="vaccinationInfoCreateDTO"></param>
        /// <returns>Newly created vaccination info</returns>
        [HttpPost("createVaccinationInfo", Name = "CreateVaccinationInfoToCard")]
        public async Task<ActionResult<VaccinationInfoDTO>> GetVaccinationInfosByCardId([Required] int cardId, VaccinationInfoCreateDTO vaccinationInfoCreateDTO)
        {
            return await _vaccinationInfoService.CreateVaccinationInfoToCard(cardId, vaccinationInfoCreateDTO);
        }

        /// <summary>
        /// Update vaccination info to vaccination card
        /// </summary>
        /// <param name="vaccinationId"></param>
        /// <param name="vaccinationInfoCreateDTO"></param>
        /// <returns>Updated vaccination info</returns>
        [HttpPut("updateVaccinationInfo", Name = "UpdateVaccinvationInfoToCard")]
        public async Task<ActionResult<VaccinationInfoDTO>> UpdateVaccinvationInfoToCard([Required] int vaccinationId, VaccinationInfoCreateDTO vaccinationInfoCreateDTO)
        {
            return await _vaccinationInfoService.UpdateVaccinvationInfoToCard(vaccinationId, vaccinationInfoCreateDTO);
        }
    }
}
