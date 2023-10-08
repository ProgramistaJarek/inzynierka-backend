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

        public PatientService(IPatientRepository patientRepository, IBabysitterRepository babysitterRepository)
        {
            _repository = patientRepository;
            _babysitterRepository = babysitterRepository;
        }

        public async Task<ActionResult<string>> AddPatientWithBabysitter(AddPatientDTO addPatientDTO)
        {
            if (addPatientDTO == null)
            {
                return new BadRequestObjectResult("Lack of information");
            }

            if (addPatientDTO.Babysitter == null)
            {
                return new BadRequestObjectResult("Lack of information");
            }

            var userExistByPesel = await _repository.CheckIfUsernameExistByPesel(addPatientDTO.PESEL);

            if (userExistByPesel != null)
            {
                return new BadRequestObjectResult("User with this PESEL exist");
            }

            var newBabysitter = new Babysitter()
            {
                FirstName = addPatientDTO.Babysitter.FirstName,
                LastName = addPatientDTO.Babysitter.LastName,
                PESEL = addPatientDTO.Babysitter.PESEL,
                Adress = addPatientDTO.Babysitter.Adress,
                PhoneNumber = addPatientDTO.Babysitter.PhoneNumber,
                Kinship = addPatientDTO.Babysitter.Kinship,
            };

            var babysitter = await _babysitterRepository.Create(newBabysitter);

            var newPatient = new Patient()
            {
                FirstName = addPatientDTO.FirstName,
                LastName = addPatientDTO.LastName,
                PESEL = addPatientDTO.PESEL,
                Adress = addPatientDTO.Adress,
                BirthDay = addPatientDTO.BirthDay,
                TypeOfVaccination = addPatientDTO.TypeOfVaccination,
                PhoneNumber = addPatientDTO.PhoneNumber,
                DateOfDeclaration = addPatientDTO.DateOfDeclaration,
                BabysitterId = babysitter.Id
            };

            var patient = await _repository.Create(newPatient);

            if (patient == null)
            {
                return new BadRequestObjectResult("Smoething went wronh");
            }

            return new OkResult();
        }
    }
}
