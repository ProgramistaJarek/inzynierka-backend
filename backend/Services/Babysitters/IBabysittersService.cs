using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.Babysitters
{
    public interface IBabysittersService
    {
        Task<ActionResult<IEnumerable<BabysitterDTO>>> GetBabysitters();
    }
}
