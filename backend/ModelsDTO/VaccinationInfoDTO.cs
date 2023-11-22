namespace backend.ModelsDTO
{
    public class VaccinationInfoDTO
    {
        public int Id { get; set; }
        public int VaccinationCardId { get; set; }
        public string PostponementOfVaccination { get; set; } = string.Empty;
        public string PostVaccinationReaction { get; set; } = string.Empty;
        public string Appointment { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public TypeVaccinationDTO TypeVaccinations { get; set; } = null!;
        public AgeGroupsDTO AgeGroups { get; set; } = null!;
        public VaccinationsDTO Vaccinations { get; set; } = null!;
    }
}
