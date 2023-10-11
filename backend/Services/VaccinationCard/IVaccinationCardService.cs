using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.VaccinationCardService
{
    public interface IVaccinationCardService
    {
        Task<ActionResult<VaccinationCardDTO>> AddVaccinationToCard(int vaccinationCardId, VaccinationInfoDTO vaccinationInfoDTO);
        Task<ActionResult<VaccinationCardDTO>> UpdateVaccinationCard(int vaccinationCardId, VaccinationCardDTO vaccinationCardDTO);
        Task<ActionResult<VaccinationCardDTO>> GetVaccinationCard(int vaccinationCardId);
        Task<ActionResult<VaccinationCardDTO>> GetVaccinationCardByPatientId(int patientId);
    }
}
