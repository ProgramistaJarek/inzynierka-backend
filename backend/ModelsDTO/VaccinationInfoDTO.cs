namespace backend.ModelsDTO
{
    public class VaccinationInfoDTO
    {
        public int Id { get; set; }
        public string PostponementOfVaccination { get; set; } = string.Empty;
        public string PostVaccinationReaction { get; set; } = string.Empty;
        public string Appointment { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string VaccinationName { get; set; } = string.Empty;
        public string VaccinvationSeries { get; set; } = string.Empty;
        public string AgeGroup { get; set; } = string.Empty;
        public string TypeVaccinations { get; set; } = string.Empty;
        public int VaccinationCardId { get; set; }
    }
}
