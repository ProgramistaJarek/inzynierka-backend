using backend.ModelsDTO;
using backend.Services.VaccinationInfoService;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("getVaccinationInfo", Name = "GetVaccinationInfo")]
        public async Task<ActionResult<VaccinationInfoCreateDTO>> GetVaccinationInfo([Required] int id)
        {
            return await _vaccinationInfoService.GetVaccinationInfo(id);
        }

        /// <summary>
        /// Get vaccination infos card by card id
        /// </summary>
        [HttpGet("getAllVaccinvationInfosByCardId", Name = "GetVaccinationInfosByCardId")]
        public async Task<ActionResult<IEnumerable<VaccinationInfoDTO>>> GetVaccinationInfosByCardId([Required] int cardId)
        {
            return await _vaccinationInfoService.GetVaccinationInfosByCardId(cardId);
        }

        /// <summary>
        /// Create vaccination info to vaccination card
        /// </summary>
        [HttpPost("createVaccinationInfo", Name = "CreateVaccinationInfoToCard")]
        public async Task<ActionResult<VaccinationInfoDTO>> GetVaccinationInfosByCardId([Required] int cardId, VaccinationInfoCreateDTO vaccinationInfoCreateDTO)
        {
            return await _vaccinationInfoService.CreateVaccinationInfoToCard(cardId, vaccinationInfoCreateDTO);
        }

        /// <summary>
        /// Update vaccination info to vaccination card
        /// </summary>
        [HttpPut("updateVaccinationInfo", Name = "UpdateVaccinvationInfoToCard")]
        public async Task<ActionResult<VaccinationInfoDTO>> UpdateVaccinvationInfoToCard([Required] int id, VaccinationInfoCreateDTO vaccinationInfoCreateDTO)
        {
            return await _vaccinationInfoService.UpdateVaccinvationInfoToCard(id, vaccinationInfoCreateDTO);
        }
    }
}
