using AutoMapper;
using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
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

        /// <summary>
        /// Get all vaccination list
        /// </summary>
        [HttpGet(Name = "getVaccinations")]
        public async Task<ActionResult<IEnumerable<VaccinationsDTO>>> GetVaccinations()
        {
            var vaccination = await _vaccinationsRepository.GetAll();
            if (vaccination == null)
            {
                return NotFound();
            }

            var result = vaccination.Select(v => _mapper.Map<VaccinationsDTO>(v)).ToList();
            return Ok(result);
        }

        /// <summary>
        /// Get vaccination by id
        /// </summary>
        [HttpGet("vaccinationById", Name = "getVaccination")]
        public async Task<ActionResult<IEnumerable<VaccinationsDTO>>> GetVaccinationById([Required] int id)
        {
            var vaccination = await _vaccinationsRepository.GetById(id);
            if (vaccination == null)
            {
                return NotFound();
            }

            var VaccinationDTO = _mapper.Map<VaccinationsDTO>(vaccination);

            return Ok(VaccinationDTO);
        }

        /// <summary>
        /// Add vaccination
        /// </summary>
        [HttpPost(Name = "createVaccination")]
        public async Task<ActionResult<IEnumerable<VaccinationsDTO>>> PostVaccination([FromBody] VaccinationsDTO vaccinationsDTO)
        {
            var vaccination = _mapper.Map<Vaccinations>(vaccinationsDTO);

            var newVaccination = await _vaccinationsRepository.Create(vaccination);

            return CreatedAtAction("GetVaccinationById", new { id = newVaccination.Id }, newVaccination);
        }

        /// <summary>
        /// Update vaccination
        /// </summary>
        [HttpPut(Name = "updateVaccination")]
        public async Task<IActionResult> PutVaccination([FromBody] VaccinationsDTO vaccinationsDTO)
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

        /// <summary>
        /// Delete vaccination by id
        /// </summary>
        [HttpDelete("removeVaccination", Name = "deleteVaccination")]
        public async Task<IActionResult> DeleteVaccination([Required] int id)
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
