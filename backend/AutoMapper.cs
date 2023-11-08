using AutoMapper;
using backend.Entities;
using backend.ModelsDTO;

namespace backend
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, SignupDTO>();
            CreateMap<SignupDTO, User>();
            CreateMap<Vaccinations, VaccinationsDTO>();
            CreateMap<VaccinationsDTO, Vaccinations>();
            CreateMap<Babysitter, BabysitterDTO>();
            CreateMap<BabysitterDTO, Babysitter>();
            CreateMap<Babysitter, BabysitterCreateDTO>();
            CreateMap<BabysitterCreateDTO, Babysitter>();
            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientDTO, Patient>();
            CreateMap<PatientInfoDTO, Patient>();
            CreateMap<Patient, PatientInfoDTO>();
            CreateMap<AddPatientWithBabysitterDTO, Patient>();
            CreateMap<Patient,AddPatientWithBabysitterDTO>();
            CreateMap<Patient, AddPatientDTO>();
            CreateMap<AddPatientDTO, Patient>();
            CreateMap<AddPatientDTO, AddPatientWithBabysitterDTO>();
            CreateMap<AddPatientWithBabysitterDTO, AddPatientDTO>();
            CreateMap<Patient,UpdatePatientDTO>();
            CreateMap<UpdatePatientDTO, Patient>();
            CreateMap<VaccinationCard, VaccinationCardDTO>();
            CreateMap<VaccinationCardDTO, VaccinationCard>();
            CreateMap<VaccinationInfo, VaccinationInfoDTO>();
            CreateMap<VaccinationInfoDTO, VaccinationInfo>();
            CreateMap<VaccinationCardCreateDTO, VaccinationCard>();
            CreateMap<VaccinationCard, VaccinationCardCreateDTO>();
            CreateMap<VaccinationInfo, VaccinationInfoCreateDTO>();
            CreateMap<VaccinationInfoCreateDTO, VaccinationInfo>();
        }
    }
}
