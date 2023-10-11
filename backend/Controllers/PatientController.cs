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

        /// <summary>
        /// Get all patients
        /// </summary>
        [HttpGet(Name = "getPatients")]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatients()
        {
            return await _patientService.GetPatients();
        }

        /// <summary>
        /// Get patient by id
        /// </summary>
        [HttpGet("{id}", Name = "getPatientById")]
        public async Task<ActionResult<PatientDTO>> GetPatient(int id)
        {
            return await _patientService.GetPatient(id);
        }

        /// <summary>
        /// Create new patient
        /// </summary>
        [HttpPost(Name = "createPatient")]
        public async Task<ActionResult<string>> PostPatient(AddPatientDTO addPatientDTO)
        {
            return await _patientService.AddPatientWithBabysitter(addPatientDTO);
        }

        /// <summary>
        /// Add to patient vaccination card
        /// </summary>
        [HttpPost("vaccinvationCard/{id}", Name = "addToPatientVaccinationCard")]
        public async Task<ActionResult<PatientDTO>> PostPatientWithVaccinationCard(int id, VaccinationCardDTO vaccinationCardDTO)
        {
            return await _patientService.AddVaccinationCardToPatient(id, vaccinationCardDTO);
        }

        /// <summary>
        /// Update patient
        /// </summary>
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

        /// <summary>
        /// Delete patient by id
        /// </summary>
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
