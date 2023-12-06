namespace backend.Entities
{
    public class PatientBabysitter
    {
        public int PatientId { get; set; }
        public int BabysitterId { get; set; }

        public Patient Patient { get; set; } = null!;
        public Babysitter Babysitter { get; set; } = null!;
    }
}
