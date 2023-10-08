using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

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
            var vaccination = await _vaccinationsRepository.GetAll();
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
            var vaccination = await _vaccinationsRepository.GetById(id);
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

            await _vaccinationsRepository.Create(vaccination);

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
            var existingVaccination = await _vaccinationsRepository.GetById(vaccination.Id);

            if (existingVaccination == null)
            {
                return NotFound();
            }

            await _vaccinationsRepository.Update(vaccination);

            return NoContent();
        }

        // DELETE: api/Vaccinations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccination(int id)
        {
            var vaccination = await _vaccinationsRepository.GetById(id);
            if (vaccination == null)
            {
                return NotFound();
            }

            await _vaccinationsRepository.Delete(id);

            return NoContent();
        }
    }
}
