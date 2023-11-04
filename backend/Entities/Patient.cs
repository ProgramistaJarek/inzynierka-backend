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
        public DateTime DateOfAbandonment { get; set; }
        public TypeOfVaccination TypeOfVaccination { get; set; }

        public int? BabysitterId { get; set; }
        public Babysitter? Babysitter { get; set; }
        public ICollection<Summons> Summons { get; set; } = new List<Summons>();
        public VaccinationCard? VaccinationCard { get; set; }
    }
}
