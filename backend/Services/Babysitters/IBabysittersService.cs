using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.Babysitters
{
#pragma warning disable CS1591 // Brak komentarza XML dla widocznego publicznie typu lub składowej
    public interface IBabysittersService
    {
        Task<ActionResult<IEnumerable<BabysitterDTO>>> GetBabysitters();
        Task<ActionResult<IEnumerable<BabysitterDTO>>> CreateNewBabysitter(int patientId, BabysitterCreateDTO babysitterDTO);
    }
#pragma warning restore CS1591 // Brak komentarza XML dla widocznego publicznie typu lub składowej
}
