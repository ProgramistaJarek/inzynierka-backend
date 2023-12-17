using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using backend.Services.Patients;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPatientService _patientService;

        public PatientController(IPatientRepository patientRepository, IPatientService patientService)
        {
            _patientRepository = patientRepository;
            _patientService = patientService;
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns>List of patients</returns>
        [HttpGet(Name = "getPatients")]
        public async Task<ActionResult<IEnumerable<PatientInfoDTO>>> GetPatients()
        {
            return await _patientService.GetPatients();
        }

        /// <summary>
        /// Get patient by id
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns>Patient object</returns>
        [HttpGet("patient", Name = "getPatientById")]
        public async Task<ActionResult<PatientDTO>> GetPatient([Required] int patientId)
        {
            return await _patientService.GetPatient(patientId);
        }

        /// <summary>
        /// Get latest vaccination scheduled
        /// </summary>
        /// <param name="count"></param>
        /// <param name="date"></param>
        /// <returns>Scheduled vaccination list</returns>
        [HttpGet("latestScheduledVaccination", Name = "GetLatestVaccinationScheduled")]
        public async Task<ActionResult<IEnumerable<LatestVaccinationInfoDTO>>> GetLatestVaccinationScheduled([Required] int count, [Required] DateTime date)
        {
            return await _patientService.GetLatestScheduledVaccination(count, date);
        }

        /// <summary>
        /// Create new patient
        /// </summary>
        /// <param name="addPatientDTO"></param>
        /// <returns>Newly created patient</returns>
        [HttpPost("createPatient", Name = "createPatient")]
        public async Task<ActionResult<PatientInfoDTO>> PostPatient([FromBody] AddPatientDTO addPatientDTO)
        {
            return await _patientService.AddPatient(addPatientDTO);
        }

        /// <summary>
        /// Add to patient vaccination card
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="vaccinationCardDTO"></param>
        /// <returns>Object of the patient</returns>
        [HttpPost("vaccinvationCard", Name = "addToPatientVaccinationCard")]
        public async Task<ActionResult<PatientDTO>> PostPatientWithVaccinationCard([Required] int patientId, [FromBody] VaccinationCardCreateDTO vaccinationCardDTO)
        {
            return await _patientService.AddVaccinationCardToPatient(patientId, vaccinationCardDTO);
        }

        /// <summary>
        /// Update patient
        /// </summary>
        /// <param name="patientDTO"></param>
        /// <returns>Updated patient</returns>
        [HttpPut(Name = "updatePatient")]
        public async Task<ActionResult<PatientInfoDTO>> PutPatient([FromBody] PatientUpdateDTO patientDTO)
        {
            return await _patientService.UpdatePatient(patientDTO);
        }

        /// <summary>
        /// Delete patient by id
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns>Response</returns>
        [HttpDelete("remove", Name = "deletePatient")]
        public async Task<IActionResult> DeletePatient([Required] int patientId)
        {
            var patient = await _patientRepository.GetById(patientId);
            if (patient == null)
            {
                return NotFound();
            }

            await _patientRepository.Delete(patientId);

            return NoContent();
        }
    }
}
