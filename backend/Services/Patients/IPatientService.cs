using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.Patients
{
#pragma warning disable CS1591 // Brak komentarza XML dla widocznego publicznie typu lub składowej
    public interface IPatientService
    {
        Task<ActionResult<string>> AddPatientWithBabysitter(AddPatientWithBabysitterDTO addPatientDTO);
        Task<ActionResult<string>> AddPatient(AddPatientDTO addPatientDTO);
        Task<ActionResult<IEnumerable<PatientDTO>>> GetPatients();
        Task<ActionResult<PatientDTO>> GetPatient(int id);
        Task<ActionResult<PatientDTO>> AddVaccinationCardToPatient(int id, VaccinationCardCreateDTO vaccinationCardDTO);
        Task<ActionResult> UpdatePatient(UpdatePatientDTO patientDTO);
        Task<ActionResult<PatientDTO>> AddBabysitterToPatient(int id, BabysitterDTO babysitterDTO);
    }
#pragma warning restore CS1591 // Brak komentarza XML dla widocznego publicznie typu lub składowej
}
