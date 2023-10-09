using AutoMapper;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.VaccinationCard
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
            if (vaccinationCard != null)
            {
                return new BadRequestObjectResult("Vaccination card with this ID do not exist");
            }



            throw new NotImplementedException();
        }
    }
}
