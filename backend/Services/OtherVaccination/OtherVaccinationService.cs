using AutoMapper;
using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.OtherVaccinationService
{
    public class OtherVaccinationService : IOtherVaccinationService
    {
        private readonly IOtherVaccinationRepository _otherVaccinationRepository;
        private readonly IVaccinationCardRepository _vaccinationCardRepository;
        private readonly IMapper _mapper;

        public OtherVaccinationService(IOtherVaccinationRepository otherVaccinationRepository, IMapper mapper, IVaccinationCardRepository vaccinationCardRepository)
        {
            _otherVaccinationRepository = otherVaccinationRepository;
            _mapper = mapper;
            _vaccinationCardRepository = vaccinationCardRepository;
        }

        public async Task<ActionResult<OtherVaccinationDTO>> CreateOtherVaccinvationToCard(int cardId, OtherVaccinationCreateDTO OtherVaccinationDTO)
        {
            var vaccinationCard = await _vaccinationCardRepository.GetById(cardId);
            if (vaccinationCard == null)
            {
                return new NotFoundObjectResult("Vaccination card with this ID do not exist");
            }

            var otherVaccination = _mapper.Map<OtherVaccination>(OtherVaccinationDTO);
            otherVaccination.VaccinationCardId = cardId;

            try
            {
                var result = await _otherVaccinationRepository.Create(otherVaccination);
                var resultDTO = _mapper.Map<OtherVaccinationDTO>(result);
                return new OkObjectResult(resultDTO);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Other vaccination cannot be added");
            }
        }

        public async Task<ActionResult<IEnumerable<OtherVaccinationDTO>>> GetOtherVaccinationsByCardId(int cardId)
        {
            var vaccinationCard = await _vaccinationCardRepository.GetById(cardId);
            if (vaccinationCard == null)
            {
                return new NotFoundObjectResult("Vaccination card with this ID do not exist");
            }

            var otherVaccination = await _otherVaccinationRepository.GetOtherVaccinvationByCardId(cardId);
            if (otherVaccination == null)
            {
                return new NotFoundObjectResult("Not found other vaccination belongs to card");
            }

            var result = _mapper.Map<IEnumerable<OtherVaccinationDTO>>(otherVaccination);

            return new OkObjectResult(result);
        }

        public async Task<ActionResult<OtherVaccinationDTO>> UpdateOtherVaccinvationToCard(int id, OtherVaccinationCreateDTO UpdateOtherVaccinationDTO)
        {
            var vaccination = await _otherVaccinationRepository.GetById(id);
            if (vaccination == null)
            {
                return new NotFoundObjectResult("Other vaccination do not exist");
            }

            var vaccinationCard = await _vaccinationCardRepository.GetById(vaccination.VaccinationCardId);
            if (vaccinationCard == null)
            {
                return new NotFoundObjectResult("Vaccination card with this ID do not exist");
            }

            var updateOtherVaccination = _mapper.Map<OtherVaccination>(UpdateOtherVaccinationDTO);

            try
            {
                var result = await _otherVaccinationRepository.Update(updateOtherVaccination);
                var resultDTO = _mapper.Map<OtherVaccinationDTO>(result);
                return new OkObjectResult(resultDTO);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Other vaccination cannot be updated");
            }
        }

        public Task<ActionResult<OtherVaccinationDTO>> DeleteOtherVaccinvationToCard(int id)
        {
            throw new NotImplementedException();
        }
    }
}
