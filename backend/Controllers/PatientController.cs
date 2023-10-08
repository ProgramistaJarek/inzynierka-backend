using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        // GET: api/Patient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatients()
        {
            var patient = await _patientRepository.GetAll();
            if (patient == null)
            {
                return NotFound();
            }
            return patient.Select(patient => new PatientDTO()
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Adress = patient.Adress,
                PESEL = patient.PESEL,
                BirthDay = patient.BirthDay,
                PhoneNumber = patient.PhoneNumber,
            }).ToList();
        }

        // GET: api/Patient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> GetPatient(int id)
        {
            var patient = await _patientRepository.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return new PatientDTO()
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Adress = patient.Adress,
                PESEL = patient.PESEL,
                BirthDay = patient.BirthDay,
                PhoneNumber = patient.PhoneNumber
            };
        }

        // POST: api/Patient
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientDTO>> PostPatient(PatientDTO patientDTO)
        {
            var patient = new Patient()
            {
                FirstName = patientDTO.FirstName,
                LastName = patientDTO.LastName,
                Adress = patientDTO.Adress,
                PESEL = patientDTO.PESEL,
                BirthDay = patientDTO.BirthDay,
                PhoneNumber = patientDTO.PhoneNumber
            };

            var craetedPatient = await _patientRepository.Create(patient);

            if (craetedPatient == null)
            {
                return Problem("Entity set 'DatabaseContext.Patients'  is null.");
            }

            return CreatedAtAction("GetPatient", new { id = craetedPatient.Id }, craetedPatient);
        }

        // PUT: api/Patient/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, PatientDTO patientDTO)
        {
            var exisitngPatient = await _patientRepository.GetById(id);

            if (exisitngPatient == null)
            {
                return NotFound();
            }

            var updatePatient = new Patient()
            {
                FirstName = patientDTO.FirstName,
                LastName = patientDTO.LastName,
                BirthDay = patientDTO.BirthDay,
                Adress = patientDTO.Adress,
                PESEL = patientDTO.PESEL,
                PhoneNumber = patientDTO.PhoneNumber
            };

            await _patientRepository.Update(updatePatient);

            return NoContent();
        }

        // DELETE: api/Patient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
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
