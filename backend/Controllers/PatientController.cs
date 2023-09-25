using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using backend.ModelsDTO;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PatientController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Patient
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatients()
        {
            if (_context.Patients == null)
            {
                return NotFound();
            }
            return await _context.Patients.Select(patient => new PatientDTO()
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Adress = patient.Adress,
                PESEL = patient.PESEL,
                BirthDay = patient.BirthDay,
                PhoneNumber = patient.PhoneNumber,
            }).ToListAsync();
        }

        // GET: api/Patient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> GetPatient(int id)
        {
            if (_context.Patients == null)
            {
                return NotFound();
            }
            var patient = await _context.Patients.FindAsync(id);

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

        // PUT: api/Patient/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, PatientDTO patientDTO)
        {
            if (id != patientDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(patientDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Patient
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientDTO>> PostPatient(PatientDTO patientDTO)
        {
            if (_context.Patients == null)
            {
                return Problem("Entity set 'DatabaseContext.Patients'  is null.");
            }
            _context.Patients.Add(new Patient()
            {
                Id = patientDTO.Id,
                FirstName = patientDTO.FirstName,
                LastName = patientDTO.LastName,
                Adress = patientDTO.Adress,
                PESEL = patientDTO.PESEL,
                BirthDay = patientDTO.BirthDay,
                PhoneNumber = patientDTO.PhoneNumber
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient", new { id = patientDTO.Id }, patientDTO);
        }

        // DELETE: api/Patient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            if (_context.Patients == null)
            {
                return NotFound();
            }
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(int id)
        {
            return (_context.Patients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
