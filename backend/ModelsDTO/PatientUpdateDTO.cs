using backend.Enums;
using backend.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.ModelsDTO
{
    public class PatientUpdateDTO
    {
        [Required] public int Id { get; set; }
        [Required] public string FirstName { get; set; } = string.Empty;
        [Required] public string LastName { get; set; } = string.Empty;
        [Required] public string PESEL { get; set; } = string.Empty;
        [Required] public string Address { get; set; } = string.Empty;
        [Required] public string PhoneNumber { get; set; } = string.Empty;
        [Required] public DateTime BirthDay { get; set; }

        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? DateOfDeclaration { get; set; }

        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? DateOfAbandonment { get; set; }
        [Required] public TypeOfVaccination TypeOfVaccination { get; set; }
    }
}
