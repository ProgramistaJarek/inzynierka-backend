using backend.ModelsDTO;
using backend.Services.Babysitters;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BabysittersController : ControllerBase
    {
        private readonly IBabysittersService _babysittersService;

        public BabysittersController(IBabysittersService babysittersService)
        {
            _babysittersService = babysittersService;
        }

        /// <summary>
        /// Get all babysitter
        /// </summary>
        [HttpGet(Name = "getBabysitters")]
        public async Task<ActionResult<IEnumerable<BabysitterDTO>>> GetBabysitters()
        {
            return await _babysittersService.GetBabysitters();
        }

        /// <summary>
        /// Add new babysitter to patient by patientId
        /// </summary>
        [HttpPost("{patientId}", Name = "addNewBabysitter")]
        public async Task<ActionResult<BabysitterDTO>> AddBabysitter(int patientId, [FromBody] BabysitterCreateDTO babysitterDTO)
        {
            return await _babysittersService.CreateNewBabysitter(patientId, babysitterDTO);
        }

        /// <summary>
        /// Update babysitter
        /// </summary>
        [HttpPut("{id}", Name = "updateBabysitter")]
        public async Task<ActionResult<BabysitterDTO>> UpdateBabysitter(int id, [FromBody] BabysitterDTO babysitterDTO)
        {
            return await _babysittersService.UpdateBabysitter(id, babysitterDTO);
        }

        /// <summary>
        /// Remove babysitter
        /// </summary>
        [HttpDelete("{babysitterId}/patientId", Name = "removeBabysitter")]
        public async Task<ActionResult> removeBabysitter(int babysitterId, int patientId)
        {
            return await _babysittersService.RemoveBabysitter(babysitterId, patientId);
        }
    }
}
