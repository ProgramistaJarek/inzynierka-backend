using backend.Enums;

namespace backend.ModelsDTO
{
    public class PatientInfoDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PESEL { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; }
        public DateTime DateOfDeclaration { get; set; }
        public DateTime DateOfAbandonment { get; set; }
        public TypeOfVaccination TypeOfVaccination { get; set; }
    }
}
