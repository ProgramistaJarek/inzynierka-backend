using backend.Utilities;
using System.Text.Json.Serialization;

namespace backend.ModelsDTO
{
    public class LatestVaccinationInfoDTO
    {
        public int Id { get; set; }
        public int VaccinationCardId { get; set; }
        public int PatientId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Dose { get; set; }
        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? Date { get; set; }
        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? ScheduledVaccination { get; set; }
        public string TypeVaccinationName { get; set; } = string.Empty;
        public string AgeGroup { get; set; } = string.Empty;
        public string VaccinationName { get; set; } = string.Empty;
        public string VaccinationSeries { get; set; } = string.Empty;
        public string VaccinationExpirationDate { get; set; } = string.Empty;
    }
}
