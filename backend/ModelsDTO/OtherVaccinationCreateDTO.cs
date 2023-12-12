namespace backend.ModelsDTO
{
    public class OtherVaccinationCreateDTO
    {
        public string PostponementOfVaccination { get; set; } = string.Empty;
        public string PostVaccinationReaction { get; set; } = string.Empty;
        public string TypeVaccination { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public string Appointment { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public DateTime? ScheduledVaccination { get; set; }
        public int Dose { get; set; }
        public int VaccinationId { get; set; }
    }
}
