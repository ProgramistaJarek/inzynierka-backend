using AutoMapper;
using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace backend.Services.Babysitters
{
    public class BabysittersService : IBabysittersService
    {
        private readonly IBabysitterRepository _babysitterRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IPatientBabysitterRepository _patientBabysitterRepository;

        private readonly IMapper _mapper;

        public BabysittersService(IBabysitterRepository babysitterRepository, IPatientRepository patientRepository, IMapper mapper, IPatientBabysitterRepository patientBabysitterRepository)
        {
            _babysitterRepository = babysitterRepository;
            _patientRepository = patientRepository;
            _mapper = mapper;
            _patientBabysitterRepository = patientBabysitterRepository;
        }

        /// <summary>
        /// Create new babysitter and add to patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="babysitterDTO"></param>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<BabysitterDTO>>> CreateNewBabysitter(int patientId, BabysitterCreateDTO babysitterDTO)
        {
            var patient = await _patientRepository.GetById(patientId);

            if (patient == null)
            {
                return new NotFoundObjectResult("User with this ID do not exist");
            }

            var existingBabysitter = await _babysitterRepository.CheckIfBabysitterExistByPesel(babysitterDTO.PESEL);

            if (existingBabysitter != null)
            {
                return new ConflictObjectResult("Babysitter with this PESEL already exists");
            }

            var map = _mapper.Map<Babysitter>(babysitterDTO);
            var babysitter = await _babysitterRepository.Create(map);

            if (babysitter == null)
            {
                return new BadRequestObjectResult("Something go wrong");
            }

            var patientBabysitter = new PatientBabysitter
            {
                PatientId = patient.Id,
                BabysitterId = babysitter.Id
            };

            await _patientBabysitterRepository.Create(patientBabysitter);

            var mapToBabysitterDTO = _mapper.Map<BabysitterDTO>(babysitter);

            return new OkObjectResult(mapToBabysitterDTO);
        }

        /// <summary>
        /// Return all babysitters
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<BabysitterDTO>>> GetBabysitters()
        {
            var list = await _babysitterRepository.GetAll();

            if (list == null)
            {
                return new NotFoundResult();
            }

            var babysittersDTO = list.Select(babysitter => _mapper.Map<BabysitterDTO>(babysitter)).ToList();

            return babysittersDTO;
        }
    }
}
