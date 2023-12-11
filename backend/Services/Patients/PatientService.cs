using AutoMapper;
using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.Patients
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IBabysitterRepository _babysitterRepository;
        private readonly IVaccinationCardRepository _vaccinationCardRepository;
        private readonly IVaccinationInfoRepository _vaccinationInfoRepository;

        private readonly IMapper _mapper;

        public PatientService(
            IPatientRepository patientRepository,
            IBabysitterRepository babysitterRepository,
            IMapper mapper,
            IVaccinationCardRepository vaccinationCardRepository,
            IVaccinationInfoRepository vaccinationInfoRepository)
        {
            _repository = patientRepository;
            _babysitterRepository = babysitterRepository;
            _mapper = mapper;
            _vaccinationCardRepository = vaccinationCardRepository;
            _vaccinationInfoRepository = vaccinationInfoRepository;
        }

        /// <summary>
        /// Add patient with babysitter
        /// </summary>
        /// <param name="addPatientDTO"></param>
        /// <returns></returns>
        public async Task<ActionResult<string>> AddPatientWithBabysitter(AddPatientWithBabysitterDTO addPatientDTO)
        {
            var patientExistByPesel = await _repository.CheckIfPatientExistByPesel(addPatientDTO.PESEL);

            if (patientExistByPesel != null)
            {
                return new NotFoundObjectResult("Patient with this PESEL exist");
            }

            if (addPatientDTO.BabysitterId <= 0 && addPatientDTO.Babysitter == null)
            {
                return new BadRequestObjectResult("You need to add babysiter");
            }

            if (addPatientDTO.Babysitter != null)
            {
                if (await _babysitterRepository.CheckIfBabysitterExistByPesel(addPatientDTO.Babysitter.PESEL) != null)
                {
                    return new NotFoundObjectResult("Babysitter with this PESEL exist");
                }
            }

            if (addPatientDTO.BabysitterId > 0)
            {
                if (await _babysitterRepository.GetById(addPatientDTO.BabysitterId) == null)
                {
                    return new NotFoundObjectResult("Babysitter with this id do not exist");
                }
            }

            var patientMap = _mapper.Map<AddPatientDTO>(addPatientDTO);
            var patient = await CreatePatient(patientMap, addPatientDTO.Babysitter);

            if (patient == null)
            {
                return new BadRequestObjectResult("Patient do not added");
            }

            return new OkResult();
        }

        /// <summary>
        /// Create patient
        /// </summary>
        /// <param name="newPatientDTO"></param>
        /// <param name="babysitterDTO"></param>
        /// <returns></returns>
        private async Task<Patient> CreatePatient(AddPatientDTO newPatientDTO, BabysitterDTO? babysitterDTO)
        {
            if (babysitterDTO != null)
            {
                var newBabysitter = _mapper.Map<Babysitter>(babysitterDTO);
                var babysitter = await _babysitterRepository.Create(newBabysitter);

                var newPatient = _mapper.Map<Patient>(newPatientDTO);
                await _babysitterRepository.Create(babysitter);

                return await _repository.Create(newPatient);
            }
            else
            {
                var newPatient = _mapper.Map<Patient>(newPatientDTO);
                return await _repository.Create(newPatient);
            }
        }

        /// <summary>
        /// Get patient with babysitter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<PatientDTO>> GetPatient(int id)
        {
            var patient = await _repository.GetPatient(id);

            if (patient == null)
            {
                return new NotFoundObjectResult("Patient with this ID do not exist");
            }

            var babysitterList = patient.PatientBabysitter.Select(pb => _mapper.Map<BabysitterDTO>(pb.Babysitter)).ToList();

            var patientDTO = _mapper.Map<PatientDTO>(patient);
            patientDTO.Babysitter = babysitterList;

            return new OkObjectResult(patientDTO);
        }

        /// <summary>
        /// Add vaccination card to Patient
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vaccinationCardDTO"></param>
        /// <returns></returns>
        public async Task<ActionResult<PatientDTO>> AddVaccinationCardToPatient(int id, VaccinationCardCreateDTO vaccinationCardDTO)
        {
            var patient = await _repository.GetById(id);

            if (patient == null)
            {
                return new NotFoundObjectResult("Patient with this ID do not exist");
            }

            var vaccinationCard = await _vaccinationCardRepository.GetVaccinationCardByPatientId(id);

            if (vaccinationCard != null)
            {
                return new BadRequestObjectResult("Vaccination card already exist for this patient");
            }

            var newCardMap = _mapper.Map<VaccinationCard>(vaccinationCardDTO);
            newCardMap.PatientId = id;

            var newCard = await _vaccinationCardRepository.Create(newCardMap);

            if (newCard == null)
            {
                return new BadRequestObjectResult("Something went wrong when adding vaccination card to patient");
            }

            var patientToReturn = _mapper.Map<PatientDTO>(patient);
            patientToReturn.VaccinationCard = _mapper.Map<VaccinationCardDTO>(newCard);

            return new OkObjectResult(patientToReturn);
        }

        /// <summary>
        /// Get patients list
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<PatientInfoDTO>>> GetPatients()
        {
            var patients = await _repository.GetPatients();

            if (patients == null)
            {
                return new NotFoundResult();
            }

            var patientDTOs = _mapper.Map<IEnumerable<PatientInfoDTO>>(patients);
            return new OkObjectResult(patientDTOs.ToList());
        }

        /// <summary>
        /// Update patient
        /// </summary>
        /// <param name="patientDTO"></param>
        /// <returns></returns>
        public async Task<ActionResult<PatientInfoDTO>> UpdatePatient(PatientUpdateDTO patientDTO)
        {
            var patinet = await _repository.GetById(patientDTO.Id);

            if (patinet == null)
            {
                return new NotFoundResult();
            }

            /*if (patientDTO.BabysitterId <= 0) patientDTO.BabysitterId = (int)patinet.BabysitterId;*/

            var patientMap = _mapper.Map<Patient>(patientDTO);
            var result = await _repository.Update(patientMap);

            var resultDTO = _mapper.Map<PatientInfoDTO>(result);

            return new OkObjectResult(resultDTO);
        }

        /// <summary>
        /// Add babysitter to patient
        /// </summary>
        /// <param name="id"></param>
        /// <param name="babysitterDTO"></param>
        /// <returns></returns>
        public async Task<ActionResult<PatientDTO>> AddBabysitterToPatient(int id, BabysitterDTO babysitterDTO)
        {
            var patient = await _repository.GetById(id);

            if (patient == null)
            {
                return new NotFoundResult();
            }

            if (babysitterDTO == null)
            {
                return new BadRequestObjectResult("You need to provide babysiter");
            }

            if (await _babysitterRepository.CheckIfBabysitterExistByPesel(babysitterDTO.PESEL) != null)
            {
                return new NotFoundObjectResult("Babysitter with this PESEL exist");
            }

            var babysitter = _mapper.Map<Babysitter>(babysitterDTO);

            var newBabysitter = await _babysitterRepository.Create(babysitter);

            await _babysitterRepository.Create(newBabysitter);
            var newPatient = await _repository.Update(patient);

            return new OkObjectResult(newPatient);
        }

        /// <summary>
        /// Add patient
        /// </summary>
        /// <param name="addPatientDTO"></param>
        /// <returns></returns>
        public async Task<ActionResult<PatientInfoDTO>> AddPatient(AddPatientDTO addPatientDTO)
        {
            var patientExistByPesel = await _repository.CheckIfPatientExistByPesel(addPatientDTO.PESEL);

            if (patientExistByPesel != null)
            {
                return new BadRequestObjectResult("Patient with this PESEL exist");
            }

            var patientMap = _mapper.Map<AddPatientDTO>(addPatientDTO);
            var patient = await CreatePatient(patientMap, null);

            if (patient == null)
            {
                return new BadRequestObjectResult("Patient do not added");
            }

            var result = _mapper.Map<PatientInfoDTO>(patient);

            return new OkObjectResult(result);
        }

        // For now it is not neccessery to use
        public async Task<ActionResult<IEnumerable<VaccinationCardDTO>>> GetLatestVaccinationScheduled(int count)
        {
            var vaccinationCard = await _vaccinationCardRepository.GetScheduledVaccinationInfo(count);
            if (vaccinationCard == null)
            {
                return new BadRequestObjectResult("Not found");
            }
            // var result = _mapper.Map<IEnumerable<VaccinationCardDTO>>(vaccinationCard);

            return new OkObjectResult(vaccinationCard);
        }

        public async Task<ActionResult<IEnumerable<LatestVaccinationInfoDTO>>> GetLatestScheduledVaccination(int count, DateTime date)
        {
            var infos = await _vaccinationInfoRepository.GetLatestScheduledVaccination(count, date);
            if (infos == null)
            {
                return new BadRequestObjectResult("Not found");
            }
            var result = _mapper.Map<IEnumerable<LatestVaccinationInfoDTO>>(infos);

            return new OkObjectResult(result);
        }
    }
}
