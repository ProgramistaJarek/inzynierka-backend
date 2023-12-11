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
        [HttpGet(Name = "getPatients")]
        public async Task<ActionResult<IEnumerable<PatientInfoDTO>>> GetPatients()
        {
            return await _patientService.GetPatients();
        }

        /// <summary>
        /// Get patient by id
        /// </summary>
        [HttpGet("byId", Name = "getPatientById")]
        public async Task<ActionResult<PatientDTO>> GetPatient([Required] int id)
        {
            return await _patientService.GetPatient(id);
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        [HttpGet("latestScheduledVaccination", Name = "GetLatestVaccinationScheduled")]
        public async Task<ActionResult<IEnumerable<LatestVaccinationInfoDTO>>> GetLatestVaccinationScheduled([Required] int count, [Required] DateTime date)
        {
            return await _patientService.GetLatestScheduledVaccination(count, date);
        }

        /// <summary>
        /// Create new patient with babysitter
        /// </summary>
        /*[HttpPost("createPatientWithBabysitter", Name = "createPatientWithBabysitter")]
        public async Task<ActionResult<string>> PostPatientWithBabysitter([FromBody] AddPatientWithBabysitterDTO addPatientDTO)
        {
            return await _patientService.AddPatientWithBabysitter(addPatientDTO);
        }*/

        /// <summary>
        /// Create new patient
        /// </summary>
        [HttpPost("createPatient", Name = "createPatient")]
        public async Task<ActionResult<PatientInfoDTO>> PostPatient([FromBody] AddPatientDTO addPatientDTO)
        {
            return await _patientService.AddPatient(addPatientDTO);
        }

        /// <summary>
        /// Add to patient vaccination card
        /// </summary>
        [HttpPost("vaccinvationCard", Name = "addToPatientVaccinationCard")]
        public async Task<ActionResult<PatientDTO>> PostPatientWithVaccinationCard([Required] int id, [FromBody] VaccinationCardCreateDTO vaccinationCardDTO)
        {
            return await _patientService.AddVaccinationCardToPatient(id, vaccinationCardDTO);
        }

        /// <summary>
        /// Update patient
        /// </summary>
        [HttpPut(Name = "updatePatient")]
        public async Task<ActionResult<PatientInfoDTO>> PutPatient([FromBody] PatientUpdateDTO patientDTO)
        {
            return await _patientService.UpdatePatient(patientDTO);
        }

        /// <summary>
        /// Delete patient by id
        /// </summary>
        [HttpDelete("remove", Name = "deletePatient")]
        public async Task<IActionResult> DeletePatient([Required] int id)
        {
            var patient = await _patientRepository.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            await _patientRepository.Delete(id);

            return NoContent();
        }
    }
}
