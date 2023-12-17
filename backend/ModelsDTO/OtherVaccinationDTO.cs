using backend.Utilities;
using System.Text.Json.Serialization;

namespace backend.ModelsDTO
{
    public class OtherVaccinationDTO
    {
        public int Id { get; set; }
        public string PostponementOfVaccination { get; set; } = string.Empty;
        public string PostVaccinationReaction { get; set; } = string.Empty;
        public string TypeVaccination { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public string Appointment { get; set; } = string.Empty;

        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? Date { get; set; }

        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? ScheduledVaccination { get; set; }
        public int Dose { get; set; }
        public int VaccinationCardId { get; set; }
        public string VaccinationName { get; set; } = string.Empty;
        public string VaccinationSeries { get; set; } = string.Empty;
    }
}
