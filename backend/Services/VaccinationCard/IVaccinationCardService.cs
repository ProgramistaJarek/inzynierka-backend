using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.VaccinationCard
{
    public interface IVaccinationCardService
    {
        Task<ActionResult<VaccinationCardDTO>> AddVaccinationToCard(int vaccinationCardId, VaccinationInfoDTO vaccinationInfoDTO);
    }
}
