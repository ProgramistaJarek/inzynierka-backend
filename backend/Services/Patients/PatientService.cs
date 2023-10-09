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
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IBabysitterRepository babysitterRepository, IMapper mapper)
        {
            _repository = patientRepository;
            _babysitterRepository = babysitterRepository;
            _mapper = mapper;
        }

        //Add patient with babysitter
        public async Task<ActionResult<string>> AddPatientWithBabysitter(AddPatientDTO addPatientDTO)
        {
            var patientExistByPesel = await _repository.CheckIfPatientExistByPesel(addPatientDTO.PESEL);

            if (patientExistByPesel != null)
            {
                return new BadRequestObjectResult("Patient with this PESEL exist");
            }

            if (addPatientDTO.Babysitter != null)
            {
                if (await _babysitterRepository.CheckIfBabysitterExistByPesel(addPatientDTO.Babysitter.PESEL) != null)
                {
                    return new BadRequestObjectResult("Babysitter with this PESEL exist");
                }
            }

            var patient = await AddPatient(addPatientDTO, addPatientDTO.Babysitter);

            if (patient == null)
            {
                return new BadRequestObjectResult("Patient do not added");
            }

            return new OkResult();
        }

        private async Task<Patient> AddPatient(AddPatientDTO newPatientDTO, BabysitterDTO? babysitterDTO)
        {
            if (babysitterDTO != null)
            {
                var newBabysitter = _mapper.Map<Babysitter>(babysitterDTO);
                var babysitter = await _babysitterRepository.Create(newBabysitter);

                var newPatient = _mapper.Map<Patient>(newPatientDTO);
                newPatient.BabysitterId = babysitter.Id;

                return await _repository.Create(newPatient);
            }
            else
            {
                var newPatient = _mapper.Map<Patient>(newPatientDTO);
                return await _repository.Create(newPatient);
            }
        }

        // Get patient with babysitter
        public async Task<ActionResult<PatientDTO>> GetPatientWithBabysitter(int id)
        {
            var patient = await _repository.GetById(id);

            if (patient == null)
            {
                return new BadRequestObjectResult("Patient with this ID do not exist");
            }

            var babysitter = await _babysitterRepository.GetById(patient.BabysitterId);

            var patientDTO = _mapper.Map<PatientDTO>(patient);
            patientDTO.Babysitter = _mapper.Map<BabysitterDTO>(babysitter);

            return patientDTO;
        }
    }
}
