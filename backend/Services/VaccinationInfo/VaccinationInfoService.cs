using AutoMapper;
using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.VaccinationInfoService
{
    public class VaccinationInfoService : IVaccinationInfoService
    {
        private readonly IVaccinationInfoRepository _vaccinationInfoRepository;
        private readonly IVaccinationCardRepository _vaccinationCardRepository;
        private readonly IVaccinationsRepository _vaccinationsRepository;
        private readonly IMapper _mapper;

        public VaccinationInfoService(IVaccinationInfoRepository vaccinationInfoRepository, IMapper mapper, IVaccinationCardRepository vaccinationCardRepository, IVaccinationsRepository vaccinationsRepository)
        {
            _vaccinationInfoRepository = vaccinationInfoRepository;
            _mapper = mapper;
            _vaccinationCardRepository = vaccinationCardRepository;
            _vaccinationsRepository = vaccinationsRepository;
        }

        public async Task<ActionResult<VaccinationInfoDTO>> CreateVaccinationInfoToCard(int cardId, VaccinationInfoCreateDTO vaccinationInfoCreateDTO)
        {
            var vaccinationCard = await _vaccinationCardRepository.GetById(cardId);
            if (vaccinationCard == null)
            {
                return new NotFoundObjectResult("Vaccination card with this ID do not exist");
            }

            var vaccinationInfo = _mapper.Map<VaccinationInfo>(vaccinationInfoCreateDTO);
            vaccinationInfo.VaccinationCardId = cardId;

            var checkIfExist = await _vaccinationInfoRepository.CheckIfVaccinationExist(vaccinationInfo);
            if (checkIfExist)
            {
                return new NotFoundObjectResult("There is already the same vacinnation added");
            }

            TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            if (vaccinationInfoCreateDTO.Date != null)
            {
                vaccinationInfo.Date = TimeZoneInfo.ConvertTimeFromUtc(vaccinationInfo.Date, targetTimeZone);
            }
            if (vaccinationInfoCreateDTO.ScheduledVaccination != null)
            {
                vaccinationInfo.ScheduledVaccination = TimeZoneInfo.ConvertTimeFromUtc(vaccinationInfo.ScheduledVaccination, targetTimeZone);
            }

            var reductionResult = await _vaccinationsRepository.ReduceVaccinationLeft(vaccinationInfo.VaccinationId, 1);

            if (!reductionResult)
            {
                return new BadRequestObjectResult("No available vaccinations left");
            }

            try
            {
                var result = await _vaccinationInfoRepository.Create(vaccinationInfo);
                var resultDTO = _mapper.Map<VaccinationInfoDTO>(result);
                return new OkObjectResult(resultDTO);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Other vaccination cannot be added");
            }
        }

        public async Task<ActionResult<IEnumerable<VaccinationInfoDTO>>> GetVaccinationInfosByCardId(int cardId)
        {
            var vaccinationCard = await _vaccinationCardRepository.GetById(cardId);
            if (vaccinationCard == null)
            {
                return new NotFoundObjectResult("Vaccination card with this ID do not exist");
            }

            var vaccinationInfoList = await _vaccinationInfoRepository.GetVaccinationInfoByCardId(cardId);
            if (vaccinationInfoList == null)
            {
                return new NotFoundObjectResult("Not found vaccination infos belongs to card");
            }

            var result = _mapper.Map<IEnumerable<VaccinationInfoDTO>>(vaccinationInfoList);
            return new OkObjectResult(result);
        }

        public async Task<ActionResult<VaccinationInfoDTO>> UpdateVaccinvationInfoToCard(int id, VaccinationInfoCreateDTO vaccinationInfoCreateDTO)
        {
            var vaccination = await _vaccinationInfoRepository.GetById(id);
            if (vaccination == null)
            {
                return new NotFoundObjectResult("Vaccination info do not exist");
            }

            var vaccinationCard = await _vaccinationCardRepository.GetById(vaccination.VaccinationCardId);
            if (vaccinationCard == null)
            {
                return new NotFoundObjectResult("Vaccination card with this ID do not exist");
            }

            var vaccinationInfoUpdate = _mapper.Map<VaccinationInfo>(vaccinationInfoCreateDTO);
            UpdateVaccinationInfoEntity(vaccinationInfoUpdate, vaccination);

            var checkIfExist = await _vaccinationInfoRepository.CheckIfVaccinationExistWithId(vaccinationInfoUpdate);
            if (checkIfExist)
            {
                return new NotFoundObjectResult("There is already the same vacinnation added");
            }

            if (vaccination.VaccinationId != vaccinationInfoUpdate.VaccinationId)
            {
                var reductionResult = await _vaccinationsRepository.ReduceVaccinationLeft(vaccinationInfoUpdate.VaccinationId, 1);

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
                var result = await _vaccinationInfoRepository.Update(vaccinationInfoUpdate);
                var resultDTO = _mapper.Map<VaccinationInfoDTO>(result);
                return new OkObjectResult(resultDTO);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Cannot update vaccination info");
            }
        }

        public Task<ActionResult<VaccinationInfoDTO>> DeleteVaccinvationInfoFromCard(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<VaccinationInfoCreateDTO>> GetVaccinationInfo(int id)
        {
            var info = await _vaccinationInfoRepository.GetById(id);
            if (info == null)
            {
                return new NotFoundObjectResult("Vaccination info do not exist");
            }

            var result = _mapper.Map<VaccinationInfoCreateDTO>(info);

            return new OkObjectResult(result);
        }

        private void UpdateVaccinationInfoEntity(VaccinationInfo updateEntity, VaccinationInfo existingEntity)
        {
            updateEntity.Id = updateEntity.Id > 0 ? updateEntity.Id : existingEntity.Id;
            updateEntity.AgeGroupId = updateEntity.AgeGroupId > 0 ? updateEntity.AgeGroupId : existingEntity.AgeGroupId;
            updateEntity.TypeVaccinationId = updateEntity.TypeVaccinationId > 0 ? updateEntity.TypeVaccinationId : existingEntity.TypeVaccinationId;
            updateEntity.VaccinationId = updateEntity.VaccinationId > 0 ? updateEntity.VaccinationId : existingEntity.VaccinationId;
            updateEntity.VaccinationCardId = existingEntity.VaccinationCardId;
            updateEntity.PostponementOfVaccination = updateEntity.PostponementOfVaccination != null ? updateEntity.PostponementOfVaccination : existingEntity.PostponementOfVaccination;
            updateEntity.PostVaccinationReaction = updateEntity.PostVaccinationReaction != null ? updateEntity.PostVaccinationReaction : existingEntity.PostVaccinationReaction;
        }

        /*private bool CheckIfVaccinationExist(VaccinationInfoCreateDTO updateEntity, VaccinationInfo existingEntity)
        {
            if (updateEntity.AgeGroupId == existingEntity.AgeGroupId && updateEntity.TypeVaccinationId == existingEntity.TypeVaccinationId && updateEntity.Dose == existingEntity.Dose)
                return true;
            return false;
        }*/
    }
}
