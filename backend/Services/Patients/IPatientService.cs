using backend.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.Patients
{
#pragma warning disable CS1591 // Brak komentarza XML dla widocznego publicznie typu lub składowej
    public interface IPatientService
    {
        Task<ActionResult<string>> AddPatientWithBabysitter(AddPatientWithBabysitterDTO addPatientDTO);
        Task<ActionResult<PatientInfoDTO>> AddPatient(AddPatientDTO addPatientDTO);
        Task<ActionResult<IEnumerable<PatientInfoDTO>>> GetPatients();
        Task<ActionResult<PatientDTO>> GetPatient(int id);
        Task<ActionResult<PatientDTO>> AddVaccinationCardToPatient(int id, VaccinationCardCreateDTO vaccinationCardDTO);
        Task<ActionResult<PatientInfoDTO>> UpdatePatient(PatientUpdateDTO patientDTO);
        Task<ActionResult<IEnumerable<VaccinationCardDTO>>> GetLatestVaccinationScheduled(int count);
        Task<ActionResult<IEnumerable<LatestVaccinationInfoDTO>>> GetLatestScheduledVaccination(int count, DateTime date);
    }
#pragma warning restore CS1591 // Brak komentarza XML dla widocznego publicznie typu lub składowej
}
