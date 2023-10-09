using AutoMapper;
using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class VaccinationsController : ControllerBase
    {
        private readonly IVaccinationsRepository _vaccinationsRepository;
        private readonly IMapper _mapper;

        public VaccinationsController(IVaccinationsRepository vaccinationsRepository, IMapper mapper)
        {
            _vaccinationsRepository = vaccinationsRepository;
            _mapper = mapper;
        }

        // GET: api/Vaccinations
        [HttpGet(Name = "getVaccinations")]
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
        [HttpGet("{id}", Name = "getVaccination")]
        public async Task<ActionResult<IEnumerable<VaccinationsDTO>>> GetVaccinationById(int id)
        {
            var vaccination = await _vaccinationsRepository.GetById(id);
            if (vaccination == null)
            {
                return NotFound();
            }

            var VaccinationDTO = _mapper.Map<VaccinationsDTO>(vaccination);

            return Ok(VaccinationDTO);
        }

        // POST: api/Vaccinations
        [HttpPost(Name = "createVaccination")]
        public async Task<ActionResult<IEnumerable<VaccinationsDTO>>> PostVaccination(VaccinationsDTO vaccinationsDTO)
        {
            var vaccination = _mapper.Map<Vaccinations>(vaccinationsDTO);

            var newVaccination = await _vaccinationsRepository.Create(vaccination);

            return CreatedAtAction("GetVaccinationById", new { id = newVaccination.Id }, newVaccination);
        }

        // PUT: api/Vaccinations
        [HttpPut(Name = "updateVaccination")]
        public async Task<IActionResult> PutVaccination(VaccinationsDTO vaccinationsDTO)
        {
            var vaccination = _mapper.Map<Vaccinations>(vaccinationsDTO);

            var existingVaccination = await _vaccinationsRepository.GetById(vaccination.Id);

            if (existingVaccination == null)
            {
                return NotFound();
            }

            await _vaccinationsRepository.Update(vaccination);

            return NoContent();
        }

        // DELETE: api/Vaccinations/5
        [HttpDelete("{id}", Name = "deleteVaccination")]
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
