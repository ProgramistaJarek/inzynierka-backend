namespace backend.ModelsDTO
{
    public class VaccinationCardDTO
    {
        public int Id { get; set; }
        public string Received { get; set; } = string.Empty;
        public string Send { get; set; } = string.Empty;
        public DateTime ReceivedDate { get; set; }
        public DateTime SendDate { get; set; }
        public bool Lack { get; set; }
        public string Year { get; set; } = string.Empty;
        public bool Emigration { get; set; }
        public bool Archive { get; set; }
        public int PatientId { get; set; }
        public IEnumerable<VaccinationInfoDTO> VaccinationInfo { get; set; } = null!;
    }
}
