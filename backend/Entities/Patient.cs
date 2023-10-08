using backend.Enums;

namespace backend.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PESEL { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; }
        public DateTime DateOfDeclaration { get; set; }
        public DateTime DateOfPublication { get; set; }
        public TypeOfVaccination TypeOfVaccination { get; set; }

        public ICollection<Babysitter> Babysitters { get; set; } = new List<Babysitter>();
        public ICollection<Summons> Summons { get; set; } = new List<Summons>();
        public VaccinationCard? VaccinationCard { get; set; }
    }
}
