namespace backend.Services.VaccinationInfoService
{
    public class VaccinationInfoService : IVaccinationInfoService
    {
        private readonly IVaccinationInfoRepository _vaccinationInfoRepository;
        private readonly IVaccinationCardRepository _vaccinationCardRepository;
        private readonly IMapper _mapper;

        public VaccinationInfoService(IVaccinationInfoRepository vaccinationInfoRepository, IMapper mapper, IVaccinationCardRepository vaccinationCardRepository)
        {
            _vaccinationInfoRepository = vaccinationInfoRepository;
            _mapper = mapper;
            _vaccinationCardRepository = vaccinationCardRepository;
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

            try
            {
                var result = await _vaccinationInfoRepository.Update(vaccinationInfoUpdate);
                var resultDTO = _mapper.Map<VaccinationInfoDTO>(result);
                return new OkObjectResult(resultDTO);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Vaccination info cannot be updated");
            }
        }

        public Task<ActionResult<OtherVaccinationDTO>> DeleteVaccinvationInfoFromCard(int id)
        {
            throw new NotImplementedException();
        }
    }
}
