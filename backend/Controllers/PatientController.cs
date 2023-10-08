﻿using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using backend.Services.Patients;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        // GET: api/Patient
        [HttpGet(Name = "getPatients")]
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
        [HttpGet("{id}", Name = "getPatientById")]
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
                PhoneNumber = patient.PhoneNumber,
                DateOfAbandonment = patient.DateOfAbandonment,
                DateOfDeclaration = patient.DateOfDeclaration,
                TypeOfVaccination = patient.TypeOfVaccination,
            };
        }

        // POST: api/Patient
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost(Name = "createPatient")]
        public async Task<ActionResult<string>> PostPatient(AddPatientDTO addPatientDTO)
        {
            return await _patientService.AddPatientWithBabysitter(addPatientDTO);
        }

        // PUT: api/Patient/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut(Name = "updatePatient")]
        public async Task<IActionResult> PutPatient(PatientDTO patientDTO)
        {
            var exisitngPatient = await _patientRepository.GetById(patientDTO.Id);

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
        [HttpDelete("{id}", Name = "deletePatient")]
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
