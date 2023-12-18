using backend.Utilities;
using System.Text.Json.Serialization;

namespace backend.ModelsDTO
{
    public class VaccinationInfoCreateDTO
    {
        public string PostponementOfVaccination { get; set; } = string.Empty;
        public string PostVaccinationReaction { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Appointment { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? Date { get; set; }
        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? ScheduledVaccination { get; set; }
        public int Dose { get; set; }
        public int VaccinationId { get; set; }
        public int AgeGroupId { get; set; }
        public int TypeVaccinationId { get; set; }
        // public int VaccinationCardId { get; set; }
    }
}
