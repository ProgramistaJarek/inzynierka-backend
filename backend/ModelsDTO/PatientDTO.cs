using backend.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace backend.ModelsDTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        [Required] public string FirstName { get; set; } = string.Empty;
        [Required] public string LastName { get; set; } = string.Empty;
        [Required] public string PESEL { get; set; } = string.Empty;
        [Required] public string Adress { get; set; } = string.Empty;
        [Required] public string PhoneNumber { get; set; } = string.Empty;
        [Required] public DateTime BirthDay { get; set; }
        public DateTime DateOfDeclaration { get; set; }
        public DateTime DateOfAbandonment { get; set; }
        [Required] public TypeOfVaccination TypeOfVaccination { get; set; }
        public BabysitterDTO Babysitter { get; set; } = null!;
    }
}
