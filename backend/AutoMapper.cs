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
            CreateMap<Patient, AddPatientWithBabysitterDTO>();
            CreateMap<Patient, AddPatientDTO>();
            CreateMap<AddPatientDTO, Patient>();
            CreateMap<AddPatientDTO, AddPatientWithBabysitterDTO>();
            CreateMap<AddPatientWithBabysitterDTO, AddPatientDTO>();
            CreateMap<Patient, UpdatePatientDTO>();
            CreateMap<UpdatePatientDTO, Patient>();
            CreateMap<VaccinationCard, VaccinationCardDTO>();
            CreateMap<VaccinationCardDTO, VaccinationCard>();
            // CreateMap<VaccinationInfo, VaccinationInfoDTO>();
            CreateMap<VaccinationInfoDTO, VaccinationInfo>();
            CreateMap<VaccinationCardCreateDTO, VaccinationCard>();
            CreateMap<VaccinationCard, VaccinationCardCreateDTO>();
            CreateMap<VaccinationInfo, VaccinationInfoCreateDTO>();
            CreateMap<VaccinationInfoCreateDTO, VaccinationInfo>();
            CreateMap<AgeGroups, AgeGroupsDTO>();
            CreateMap<AgeGroupsDTO, AgeGroups>();
            CreateMap<VaccinationType, VaccinationTypeDTO>();
            CreateMap<VaccinationTypeDTO, VaccinationType>();

            CreateMap<VaccinationInfo, VaccinationInfoDTO>()
                .ForMember(dest => dest.TypeVaccinationName, opt => opt.MapFrom(src => src.TypeVaccinations.Name))
                .ForMember(dest => dest.AgeGroup, opt => opt.MapFrom(src => src.AgeGroups.Name))
                .ForMember(dest => dest.VaccinationName, opt => opt.MapFrom(src => src.Vaccinations.Name))
                .ForMember(dest => dest.VaccinationSeries, opt => opt.MapFrom(src => src.Vaccinations.Series));

            CreateMap<VaccinationCard, VaccinationCardDTO>()
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.Patient.Id));
        }

    }
}
