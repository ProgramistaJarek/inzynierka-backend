namespace backend.Entities
{
    public class VaccinationInfo
    {
        public int Id { get; set; }
        public string PostponementOfVaccination { get; set; } = string.Empty;
        public string PostVaccinationReaction { get; set; } = string.Empty;
        public string Postponement { get; set; } = string.Empty;
        public string Appointment { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string VaccinationName { get; set; } = string.Empty;
        public string VaccinvationSeries { get; set; } = string.Empty;

        public int VaccinationCardId { get; set; }
        public VaccinationCard VaccinationCard { get; set; } = null!;
    }
}
