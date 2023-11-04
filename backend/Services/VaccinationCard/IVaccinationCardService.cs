using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.VaccinationCardService
{
#pragma warning disable CS1591 // Brak komentarza XML dla widocznego publicznie typu lub składowej
    public interface IVaccinationCardService
    {
        Task<ActionResult<VaccinationCardDTO>> AddVaccinationToCard(int vaccinationCardId, VaccinationInfoCreateDTO vaccinationInfoDTO);
        Task<ActionResult<VaccinationCardDTO>> UpdateVaccinationCard(int vaccinationCardId, VaccinationCardDTO vaccinationCardDTO);
        Task<ActionResult<VaccinationCardDTO>> GetVaccinationCard(int vaccinationCardId);
        Task<ActionResult<VaccinationCardDTO>> GetVaccinationCardByPatientId(int patientId);
    }
#pragma warning restore CS1591 // Brak komentarza XML dla widocznego publicznie typu lub składowej
}
