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
    }
}
