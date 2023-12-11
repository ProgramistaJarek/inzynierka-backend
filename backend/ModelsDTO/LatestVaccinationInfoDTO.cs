namespace backend.ModelsDTO
{
    public class LatestVaccinationInfoDTO
    {
        public int Id { get; set; }
        public int VaccinationCardId { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ScheduledVaccination { get; set; }
        public string TypeVaccinationName { get; set; } = string.Empty;
        public string AgeGroup { get; set; } = string.Empty;
        public string VaccinationName { get; set; } = string.Empty;
        public string VaccinationSeries { get; set; } = string.Empty;
        public string VaccinationExpirationDate { get; set; } = string.Empty;
    }
}
