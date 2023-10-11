using AutoMapper;
using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.VaccinationCardService
{
    public class VaccinationCardService : IVaccinationCardService
    {
        private readonly IVaccinationCardRepository _repository;
        private readonly IVaccinationInfoRepository _infoRepository;

        private readonly IMapper _mapper;

        public VaccinationCardService(IVaccinationCardRepository vaccinationCardRepository, IVaccinationInfoRepository vaccinationInfoRepository, IMapper mapper)
        {
            _repository = vaccinationCardRepository;
            _infoRepository = vaccinationInfoRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult<VaccinationCardDTO>> AddVaccinationToCard(int vaccinationCardId, VaccinationInfoDTO vaccinationInfoDTO)
        {
            var vaccinationCard = await _repository.GetById(vaccinationCardId);
            if (vaccinationCard == null)
            {
                return new BadRequestObjectResult("Vaccination card with this ID do not exist");
            }

            var vaccinvationInfo = _mapper.Map<VaccinationInfo>(vaccinationInfoDTO);
            vaccinvationInfo.VaccinationCardId = vaccinationCardId;
            await _infoRepository.Create(vaccinvationInfo);

            var infos = await _infoRepository.GetVaccinationInfoByCardId(vaccinationCardId);

            var card = _mapper.Map<VaccinationCardDTO>(vaccinationCard);
            card.VaccinationInfo = infos.Select(x => _mapper.Map<VaccinationInfoDTO>(x)).ToList();

            return new OkObjectResult(card);
        }

        public async Task<ActionResult<VaccinationCardDTO>> GetVaccinationCard(int vaccinationCardId)
        {
            var vaccinationCard = await _repository.GetById(vaccinationCardId);
            if (vaccinationCard == null)
            {
                return new BadRequestObjectResult("Vaccination card with this ID do not exist");
            }

            var card = _mapper.Map<VaccinationCardDTO>(vaccinationCard);

            return new OkObjectResult(card);
        }

        public async Task<ActionResult<VaccinationCardDTO>> GetVaccinationCardByPatientId(int patientId)
        {
            var vaccinationCard = await _repository.GetVaccinationCardByPatientId(patientId);
            if (vaccinationCard == null)
            {
                return new BadRequestObjectResult("Vaccination card with this ID do not exist");
            }

            var card = _mapper.Map<VaccinationCardDTO>(vaccinationCard);

            return new OkObjectResult(card);
        }

        public async Task<ActionResult<VaccinationCardDTO>> UpdateVaccinationCard(int vaccinationCardId, VaccinationCardDTO vaccinationCardDTO)
        {
            var vaccinationCard = await _repository.GetById(vaccinationCardId);
            if (vaccinationCard == null)
            {
                return new BadRequestObjectResult("Vaccination card with this ID do not exist");
            }

            var card = _mapper.Map<VaccinationCard>(vaccinationCardDTO);

            var updatedCard = await _repository.Update(card);

            return new OkObjectResult(updatedCard);
        }
    }
}
