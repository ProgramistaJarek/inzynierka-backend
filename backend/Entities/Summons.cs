namespace backend.Entities
{
    public class Summons
    {
        public int Id { get; set; }
        public string Note { get; set; } = string.Empty;
        public string Avoid { get; set; } = string.Empty;
        public DateTime Send { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
    }
}
