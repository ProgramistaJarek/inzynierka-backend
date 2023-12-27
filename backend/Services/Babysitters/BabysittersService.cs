using AutoMapper;
using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<BabysitterDTO>> CreateNewBabysitter(int patientId, BabysitterCreateDTO babysitterDTO)
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

        /// <summary>
        /// Edit babysitter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="babysitterDTO"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ActionResult<BabysitterDTO>> UpdateBabysitter(int id, BabysitterDTO babysitterDTO)
        {
            if (id != babysitterDTO.Id)
            {
                return new NotFoundObjectResult("Id's are not correct");
            }

            var babysitter = await _babysitterRepository.GetById(id);
            if (babysitter == null)
            {
                return new NotFoundObjectResult("Babysitter with this ID do not exist");
            }

            var checkBabysitterPesel = await _babysitterRepository.CheckIfBabysitterExistByPesel(babysitterDTO.PESEL);
            if (checkBabysitterPesel != null && checkBabysitterPesel.Id != id)
            {
                return new ConflictObjectResult("Something go wrong! Babysitter with this PESEL already exists");
            }

            try
            {
                babysitter = _mapper.Map<Babysitter>(babysitterDTO);
                var updatedBabysitter = await _babysitterRepository.Update(babysitter);
                babysitterDTO = _mapper.Map<BabysitterDTO>(updatedBabysitter);
                return new OkObjectResult(babysitterDTO);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Babysitter cannot be updated");
            }
        }

        /// <summary>
        /// Remove babysitter from many-to-many and delete from table babysitter
        /// </summary>
        /// <param name="babysitterId"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ActionResult> RemoveBabysitter(int babysitterId, int patientId)
        {
            var babysitter = await _babysitterRepository.GetById(babysitterId);
            if (babysitter == null)
            {
                return new NotFoundObjectResult("Babysitter with this ID do not exist");
            }

            var patient = await _patientRepository.GetById(patientId);
            if (patient == null)
            {
                return new NotFoundObjectResult("Patient with this ID do not exist");
            }

            try
            {
                var checkRelationsPB = await _patientBabysitterRepository.DoesPatientBabysitterExist(babysitterId, patientId);
                if (checkRelationsPB == null)
                {
                    return new NotFoundObjectResult("This relation do not exist");
                }

                await _patientBabysitterRepository.RemovePatientBabysitter(checkRelationsPB);
                await _babysitterRepository.Delete(babysitterId);
                return new OkObjectResult("Success");
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("The removal action encountered an error");
            }
        }
    }
}
