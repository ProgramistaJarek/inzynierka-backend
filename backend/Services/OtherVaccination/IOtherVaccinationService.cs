using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.OtherVaccinationService
{
    public interface IOtherVaccinationService
    {
        Task<ActionResult<IEnumerable<OtherVaccinationDetailsDTO>>> GetOtherVaccinationsByCardId(int cardId);
        Task<ActionResult<OtherVaccinationDetailsDTO>> CreateOtherVaccinvationToCard(int cardId, OtherVaccinationDTO OtherVaccinationDTO);
        Task<ActionResult<OtherVaccinationDetailsDTO>> UpdateOtherVaccinvationToCard(int id, OtherVaccinationDTO UpdateOtherVaccinationDTO);
        Task<ActionResult<OtherVaccinationDTO>> DeleteOtherVaccinvationToCard(int id);
    }
}
