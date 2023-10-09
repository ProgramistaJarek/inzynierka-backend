using backend.ModelsDTO;
using backend.Services.VaccinationCard;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("{id}", Name = "addVaccinationToCard")]
        public async Task<ActionResult<VaccinationCardDTO>> AddVaccinationToCard(int vaccinationCardId, VaccinationInfoDTO vaccinationInfoDTO)
        {
            return await _vaccinationCardService.AddVaccinationToCard(vaccinationCardId, vaccinationInfoDTO);
        }
    }
}
