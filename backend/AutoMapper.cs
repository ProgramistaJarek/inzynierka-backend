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
            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientDTO, Patient>();
            CreateMap<AddPatientDTO, Patient>();
            CreateMap<Patient,AddPatientDTO>();
            CreateMap<VaccinationCard, VaccinationCardDTO>();
            CreateMap<VaccinationCardDTO, VaccinationCard>();
            CreateMap<VaccinationInfo, VaccinationInfoDTO>();
            CreateMap<VaccinationInfoDTO, VaccinationInfo>();
        }
    }
}
