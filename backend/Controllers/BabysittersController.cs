using backend.ModelsDTO;
using backend.Services.Babysitters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
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
        /// <returns>List of the babysitters</returns>
        [HttpGet(Name = "getBabysitters")]
        public async Task<ActionResult<IEnumerable<BabysitterDTO>>> GetBabysitters()
        {
            return await _babysittersService.GetBabysitters();
        }

        /// <summary>
        /// Add new babysitter to patient by patientId
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="babysitterDTO"></param>
        /// <returns>New added babysitter to patient</returns>
        [HttpPost("create", Name = "addNewBabysitter")]
        public async Task<ActionResult<BabysitterDTO>> AddBabysitter([Required] int patientId, [FromBody] BabysitterCreateDTO babysitterDTO)
        {
            return await _babysittersService.CreateNewBabysitter(patientId, babysitterDTO);
        }

        /// <summary>
        /// Update babysitter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="babysitterDTO"></param>
        /// <returns>Object of the updated babysitter</returns>
        [HttpPut("update", Name = "updateBabysitter")]
        public async Task<ActionResult<BabysitterDTO>> UpdateBabysitter([Required] int id, [FromBody] BabysitterDTO babysitterDTO)
        {
            return await _babysittersService.UpdateBabysitter(id, babysitterDTO);
        }

        /// <summary>
        /// Remove babysitter 
        /// </summary>
        /// <param name="babysitterId"></param>
        /// <param name="patientId"></param>
        /// <returns>Reulst</returns>
        [HttpDelete("removeBabysitter", Name = "removeBabysitter")]
        public async Task<ActionResult> removeBabysitter([Required] int babysitterId, [Required] int patientId)
        {
            return await _babysittersService.RemoveBabysitter(babysitterId, patientId);
        }
    }
}
