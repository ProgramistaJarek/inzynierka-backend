using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.VaccinationType
{
    public interface IVaccinationTypeService
    {
        Task<ActionResult<IEnumerable<VaccinationTypeDTO>>> GetVaccinationTypes();
    }
}
