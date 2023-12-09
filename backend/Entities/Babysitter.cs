namespace backend.Entities
{
    public class Babysitter
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PESEL { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Kinship { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;

        public ICollection<PatientBabysitter> PatientBabysitter { get; set; } = new List<PatientBabysitter>();
    }
}
