namespace backend.Entities
{
    public class VaccinationCard
    {
        public int Id { get; set; }
        public string Received {  get; set; } = string.Empty;
        public string Send {  get; set; } = string.Empty;
        public DateTime ReceivedDate { get; set; }
        public DateTime SendDate { get; set; }
        public bool Lack {  get; set; }
        public string Year { get; set; } = string.Empty;
        public bool Emigration { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
        public ICollection<VaccinationInfo> VaccinationInfo { get; set; } = null!;
    }
}
