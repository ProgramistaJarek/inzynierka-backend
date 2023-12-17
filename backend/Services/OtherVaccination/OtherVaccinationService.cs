using AutoMapper;
using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.OtherVaccinationService
{
    public class OtherVaccinationService : IOtherVaccinationService
    {
        private readonly IOtherVaccinationRepository _otherVaccinationRepository;
        private readonly IVaccinationCardRepository _vaccinationCardRepository;
        private readonly IVaccinationsRepository _vaccinationsRepository;
        private readonly IMapper _mapper;

        public OtherVaccinationService(IOtherVaccinationRepository otherVaccinationRepository, IMapper mapper, IVaccinationCardRepository vaccinationCardRepository, IVaccinationsRepository vaccinationsRepository)
        {
            _otherVaccinationRepository = otherVaccinationRepository;
            _mapper = mapper;
            _vaccinationCardRepository = vaccinationCardRepository;
            _vaccinationsRepository = vaccinationsRepository;
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

            var checkIfExist = await _otherVaccinationRepository.CheckIfVaccinationExist(otherVaccination);
            if (checkIfExist)
            {
                return new NotFoundObjectResult("There is already the same vacinnation added");
            }

            var reductionResult = await _vaccinationsRepository.ReduceVaccinationLeft(OtherVaccinationDTO.VaccinationId, 1);

            if (!reductionResult)
            {
                return new BadRequestObjectResult("No available vaccinations left");
            }

            TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            if (OtherVaccinationDTO.Date != null)
            {
                otherVaccination.Date = TimeZoneInfo.ConvertTimeFromUtc(otherVaccination.Date, targetTimeZone);
            }
            if (OtherVaccinationDTO.ScheduledVaccination != null)
            {
                otherVaccination.ScheduledVaccination = TimeZoneInfo.ConvertTimeFromUtc(otherVaccination.ScheduledVaccination, targetTimeZone);
            }

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

        public async Task<ActionResult<OtherVaccinationDTO>> UpdateOtherVaccinvationToCard(int id, OtherVaccinationCreateDTO updateOtherVaccinationDTO)
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

            var updateOtherVaccination = _mapper.Map<OtherVaccination>(updateOtherVaccinationDTO);
            UpdateOtherVaccinationEntity(updateOtherVaccination, vaccination);

            var checkIfExist = await _otherVaccinationRepository.CheckIfVaccinationExistWithId(updateOtherVaccination);
            if (checkIfExist)
            {
                return new NotFoundObjectResult("There is already the same vacinnation added");
            }

            if (vaccination.VaccinationId != updateOtherVaccination.VaccinationId)
            {
                var reductionResult = await _vaccinationsRepository.ReduceVaccinationLeft(updateOtherVaccinationDTO.VaccinationId, 1);

                if (!reductionResult)
                {
                    return new BadRequestObjectResult("No available vaccinations left");
                }

                var addResult = await _vaccinationsRepository.ReduceVaccinationLeft(vaccination.VaccinationId, -1);

                if (!addResult)
                {
                    return new BadRequestObjectResult("The vaccination cannot be restored");
                }
            }

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

        public async Task<ActionResult<OtherVaccinationCreateDTO>> GetOtherVaccination(int id)
        {
            var info = await _otherVaccinationRepository.GetById(id);
            if (info == null)
            {
                return new NotFoundObjectResult("Other vaccination do not exist");
            }

            var result = _mapper.Map<OtherVaccinationCreateDTO>(info);

            return new OkObjectResult(result);
        }

        private void UpdateOtherVaccinationEntity(OtherVaccination updateEntity, OtherVaccination existingEntity)
        {
            updateEntity.Id = updateEntity.Id > 0 ? updateEntity.Id : existingEntity.Id;
            updateEntity.VaccinationId = updateEntity.VaccinationId > 0 ? updateEntity.VaccinationId : existingEntity.VaccinationId;
            updateEntity.VaccinationCardId = existingEntity.VaccinationCardId;
            updateEntity.PostponementOfVaccination = updateEntity.PostponementOfVaccination != null ? updateEntity.PostponementOfVaccination : existingEntity.PostponementOfVaccination;
            updateEntity.PostVaccinationReaction = updateEntity.PostVaccinationReaction != null ? updateEntity.PostVaccinationReaction : existingEntity.PostVaccinationReaction;
        }
    }
}
