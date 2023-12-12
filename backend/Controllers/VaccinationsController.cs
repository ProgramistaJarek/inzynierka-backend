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
        /// Get vaccination before expiration date
        /// </summary>
        [HttpGet("vaccinationBeforeExirationDate", Name = "returnVaccinationBeforeExirationDate")]
        public async Task<ActionResult<IEnumerable<VaccinationsDTO>>> ReturnVaccinationBeforeExirationDate()
        {
            var vaccination = await _vaccinationsRepository.ReturnVaccinationBeforeExirationDate();
            if (vaccination == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<IEnumerable<VaccinationsDTO>>(vaccination);
            return Ok(result);
        }

        /// <summary>
        /// Get vaccination expiring within days
        /// </summary>
        [HttpGet("vaccinationExpiringWithinDays", Name = "getVaccinationExpiringWithinDays")]
        public async Task<ActionResult<IEnumerable<VaccinationsDTO>>> GetVaccinationExpiringWithinDays([Required] int days)
        {
            var vaccination = await _vaccinationsRepository.GetVaccinationExpiringWithinDays(days);
            if (vaccination == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<IEnumerable<VaccinationsDTO>>(vaccination);
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
        public async Task<ActionResult<VaccinationsDTO>> PostVaccination([FromBody] VaccinationsDTO vaccinationsDTO)
        {
            var vaccination = _mapper.Map<Vaccinations>(vaccinationsDTO);
            vaccination.Left = vaccination.Amount;

            var newVaccination = await _vaccinationsRepository.Create(vaccination);

            var result = _mapper.Map<VaccinationsDTO>(newVaccination);

            return CreatedAtAction("GetVaccinationById", new { id = newVaccination.Id }, result);
        }

        /// <summary>
        /// Update vaccination
        /// </summary>
        [HttpPut(Name = "updateVaccination")]
        public async Task<ActionResult<VaccinationsDTO>> PutVaccination([FromBody] VaccinationsDTO vaccinationsDTO)
        {
            var vaccination = _mapper.Map<Vaccinations>(vaccinationsDTO);

            var existingVaccination = await _vaccinationsRepository.GetById(vaccination.Id);

            if (existingVaccination == null)
            {
                return NotFound();
            }

            var updateVaccination = await _vaccinationsRepository.Update(vaccination);

            var result = _mapper.Map<VaccinationsDTO>(updateVaccination);

            return Ok(result);
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
