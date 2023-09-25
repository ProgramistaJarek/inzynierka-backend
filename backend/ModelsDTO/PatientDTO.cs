namespace backend.ModelsDTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string PESEL { get; set; } = String.Empty;
        public string Adress { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public DateTime BirthDay { get; set; }
    }
}
