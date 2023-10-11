using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.Patients
{
    public interface IPatientService
    {
        Task<ActionResult<string>> AddPatientWithBabysitter(AddPatientDTO addPatientDTO);
        Task<ActionResult<IEnumerable<PatientDTO>>> GetPatients();
        Task<ActionResult<PatientDTO>> GetPatient(int id);
        Task<ActionResult<PatientDTO>> AddVaccinationCardToPatient(int id, VaccinationCardCreateDTO vaccinationCardDTO);
        Task<ActionResult> UpdatePatient(UpdatePatientDTO patientDTO);
    }
}
