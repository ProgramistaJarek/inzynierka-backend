using AutoMapper;
using backend.Entities;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        //Add patient with babysitter
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

        private async Task<Patient> CreatePatient(AddPatientDTO newPatientDTO, BabysitterDTO? babysitterDTO)
        {
            if (babysitterDTO != null)
            {
                var newBabysitter = _mapper.Map<Babysitter>(babysitterDTO);
                var babysitter = await _babysitterRepository.Create(newBabysitter);

                var newPatient = _mapper.Map<Patient>(newPatientDTO);
                newPatient.Babysitter.Add(babysitter);

                return await _repository.Create(newPatient);
            }
            else
            {
                var newPatient = _mapper.Map<Patient>(newPatientDTO);
                return await _repository.Create(newPatient);
            }
        }

        // Get patient with babysitter
        public async Task<ActionResult<PatientDTO>> GetPatient(int id)
        {
            var patient = await _repository.GetPatient(id);

            if (patient == null)
            {
                return new NotFoundObjectResult("Patient with this ID do not exist");
            }

            var patientDTO = _mapper.Map<PatientDTO>(patient);

            return patientDTO;
        }

        // Add vaccination card to Patient
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

            return patientToReturn;
        }

        // Get patients list
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatients()
        {
            var patients = await _repository.GetPatients();

            if (patients == null)
            {
                return new NotFoundResult();
            }

            var patientDTOs = _mapper.Map<IEnumerable<PatientDTO>>(patients);

            return patientDTOs.ToList();
        }

        // Update patient
        public async Task<ActionResult> UpdatePatient(UpdatePatientDTO patientDTO)
        {
            var patinet = await _repository.GetById(patientDTO.Id);

            if (patinet == null)
            {
                return new NotFoundResult();
            }

            /*if (patientDTO.BabysitterId <= 0) patientDTO.BabysitterId = (int)patinet.BabysitterId;*/

            var patientMap = _mapper.Map<Patient>(patientDTO);
            await _repository.Update(patientMap);

            return new OkResult();
        }

        // Add babysitter to patient
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

            patient.Babysitter.Add(newBabysitter);
            var newPatient = await _repository.Update(patient);

            return new OkObjectResult(newPatient);
        }

        public async Task<ActionResult<string>> AddPatient(AddPatientDTO addPatientDTO)
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

            return new OkResult();
        }

        // For now it is not neccessery to use
        private async Task<VaccinationCardDTO?> GetVaccinvationCardByPatientId(int patientId)
        {
            var vaccinationCard = await _vaccinationCardRepository.GetVaccinationCardByPatientId(patientId);
            if (vaccinationCard == null) return null;
            var vaccinationCardDTO = _mapper.Map<VaccinationCardDTO>(vaccinationCard);

            var infos = await _vaccinationInfoRepository.GetVaccinationInfoByCardId(vaccinationCardDTO.Id);
            vaccinationCardDTO.VaccinationInfo = _mapper.Map<IEnumerable<VaccinationInfoDTO>>(infos);

            return vaccinationCardDTO;
        }
    }
}
