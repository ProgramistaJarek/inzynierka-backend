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
            CreateMap<AddPatientDTO, Patient>();
            CreateMap<Patient,AddPatientDTO>();
            CreateMap<Patient,UpdatePatientDTO>();
            CreateMap<UpdatePatientDTO, Patient>();
            CreateMap<VaccinationCard, VaccinationCardDTO>();
            CreateMap<VaccinationCardDTO, VaccinationCard>();
            CreateMap<VaccinationInfo, VaccinationInfoDTO>();
            CreateMap<VaccinationInfoDTO, VaccinationInfo>();
            CreateMap<VaccinationCardCreateDTO, VaccinationCard>();
            CreateMap<VaccinationCard, VaccinationCardCreateDTO>();
            CreateMap<VaccinationCard, VaccinationInfoCreateDTO>();
            CreateMap<VaccinationInfoCreateDTO, VaccinationCard>();
        }
    }
}
