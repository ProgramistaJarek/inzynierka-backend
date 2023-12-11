using backend.Entities;
using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.VaccinationInfoService
{
    public interface IVaccinationInfoService
    {
        Task<ActionResult<IEnumerable<VaccinationInfoDTO>>> GetVaccinationInfosByCardId(int cardId);
        Task<ActionResult<VaccinationInfoDTO>> CreateVaccinationInfoToCard(int cardId, VaccinationInfoCreateDTO vaccinationInfoCreateDTO);
        Task<ActionResult<VaccinationInfoDTO>> UpdateVaccinvationInfoToCard(int id, VaccinationInfoCreateDTO vaccinationInfoCreateDTO);
        Task<ActionResult<OtherVaccinationDTO>> DeleteVaccinvationInfoFromCard(int id);
    }
}
