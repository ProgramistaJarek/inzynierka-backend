using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.OtherVaccinationService
{
    public interface IOtherVaccinationService
    {
        Task<ActionResult<IEnumerable<OtherVaccinationDTO>>> GetOtherVaccinationsByCardId(int cardId);
        Task<ActionResult<OtherVaccinationDTO>> CreateOtherVaccinvationToCard(int cardId, OtherVaccinationCreateDTO OtherVaccinationDTO);
        Task<ActionResult<OtherVaccinationDTO>> UpdateOtherVaccinvationToCard(int id, OtherVaccinationCreateDTO UpdateOtherVaccinationDTO);
        Task<ActionResult<OtherVaccinationDTO>> DeleteOtherVaccinvationToCard(int id);
    }
}
