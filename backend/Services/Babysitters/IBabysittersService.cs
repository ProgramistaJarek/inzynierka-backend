using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.Babysitters
{
#pragma warning disable CS1591 // Brak komentarza XML dla widocznego publicznie typu lub składowej
    public interface IBabysittersService
    {
        Task<ActionResult<IEnumerable<BabysitterDTO>>> GetBabysitters();
        Task<ActionResult<BabysitterDTO>> CreateNewBabysitter(int patientId, BabysitterCreateDTO babysitterDTO);
        Task<ActionResult<BabysitterDTO>> UpdateBabysitter(int id, BabysitterDTO babysitterDTO);
        Task<ActionResult> RemoveBabysitter(int babysitterId, int patientId);
    }
#pragma warning restore CS1591 // Brak komentarza XML dla widocznego publicznie typu lub składowej
}
