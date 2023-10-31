using backend.ModelsDTO;
using backend.Services.Babysitters;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        /// Add new babysitter
        /// </summary>
        [HttpPost(Name = "addNewBabysitter")]
        public async Task<ActionResult<IEnumerable<BabysitterDTO>>> AddBabysitter(BabysitterCreateDTO babysitterDTO)
        {
            return await _babysittersService.GetBabysitters();
        }
    }
}
