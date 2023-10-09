using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.Patients
{
    public interface IPatientService
    {
        Task<ActionResult<string>> AddPatientWithBabysitter(AddPatientDTO addPatientDTO);
        Task<ActionResult<PatientDTO>> GetPatientWithBabysitter(int id);
        Task<ActionResult<PatientDTO>> AddVaccinationCardToPatient(int id, VaccinationCardDTO vaccinationCardDTO);
    }
}
