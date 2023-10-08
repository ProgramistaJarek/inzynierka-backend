namespace backend.Entities
{
    public class VaccinationInfo
    {
        public int Id { get; set; }
        public string PostponementOfCaccination { get; set; } = string.Empty;
        public string PostCaccinationReaction { get; set; } = string.Empty;
        public string Postponement { get; set; } = string.Empty;
        public string Appointment { get; set; } = string.Empty;
    }
}
