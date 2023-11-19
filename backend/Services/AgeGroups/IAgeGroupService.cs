using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.AgeGroups
{
#pragma warning disable CS1591 // Brak komentarza XML dla widocznego publicznie typu lub składowej
    public interface IAgeGroupService
    {
        Task<ActionResult<IEnumerable<AgeGroupsDTO>>> GetAgeGroups();
    }
#pragma warning restore CS1591 // Brak komentarza XML dla widocznego publicznie typu lub składowej
}
