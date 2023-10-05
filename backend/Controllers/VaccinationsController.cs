using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.ModelsDTO;
using backend.Repositories;
using System.Transactions;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationsController : ControllerBase
    {
        private readonly IVaccinationsRepository _vaccinationsRepository;

        public VaccinationsController(IVaccinationsRepository vaccinationsRepository)
        {
            _vaccinationsRepository = vaccinationsRepository;
        }

        // GET: api/Vaccinations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccinationsDTO>>> GetVaccinations()
        {
            var vaccination = await _vaccinationsRepository.GetVaccinationsAsync();
            if (vaccination == null)
            {
                return NotFound();
            }

            return vaccination.Select(v => new VaccinationsDTO()
            {
                Id = v.Id,
                Name = v.Name,
                DateOfProduction = v.DateOfProduction,
                ExpirationDate = v.ExpirationDate,
                Amount = v.Amount,
            }).ToList();
        }

        // GET: api/Vaccinations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<VaccinationsDTO>>> GetVaccinationById(int id)
        {
            var vaccination = await _vaccinationsRepository.GetVaccinateByIdAsync(id);
            if (vaccination == null)
            {
                return NotFound();
            }

            var VaccinationDTO = new VaccinationsDTO()
            {
                Id = vaccination.Id,
                Name = vaccination.Name,
                DateOfProduction = vaccination.DateOfProduction,
                ExpirationDate = vaccination.ExpirationDate,
                Amount = vaccination.Amount,
            };

            return Ok(VaccinationDTO);
        }

        // POST: api/Vaccinations
        [HttpPost]
        public async Task<ActionResult<IEnumerable<VaccinationsDTO>>> PostVaccination(VaccinationsDTO vaccinationsDTO)
        {
            var vaccination = new Vaccinations()
            {
                Id = vaccinationsDTO.Id,
                Name = vaccinationsDTO.Name,
                Amount = vaccinationsDTO.Amount,
                ExpirationDate = vaccinationsDTO.ExpirationDate,
                DateOfProduction = vaccinationsDTO.DateOfProduction,
            };

            await _vaccinationsRepository.AddVaccinateAsync(vaccination);

            return CreatedAtAction("GetVaccinationById", new { id = vaccinationsDTO.Id }, vaccinationsDTO);
        }

        // PUT: api/Vaccinations
        [HttpPut]
        public async Task<IActionResult> PutVaccination(VaccinationsDTO vaccinationsDTO)
        {
            var vaccination = new Vaccinations()
            {
                Id = vaccinationsDTO.Id,
                Name = vaccinationsDTO.Name,
                Amount = vaccinationsDTO.Amount,
                DateOfProduction = vaccinationsDTO.DateOfProduction,
                ExpirationDate = vaccinationsDTO.ExpirationDate,
            };
            var existingVaccination = await _vaccinationsRepository.GetVaccinateByIdAsync(vaccination.Id);

            if (existingVaccination == null)
            {
                return NotFound();
            }

            await _vaccinationsRepository.UpdateVaccinateAsync(vaccination);

            return NoContent();
        }

        // DELETE: api/Vaccinations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccination(int id)
        {
            var vaccination = await _vaccinationsRepository.GetVaccinateByIdAsync(id);
            if (vaccination == null)
            {
                return NotFound();
            }

            await _vaccinationsRepository.DeteleVaccinateAsync(id);

            return NoContent();
        }
    }
}
