using backend.Utilities;
using System.Text.Json.Serialization;

namespace backend.ModelsDTO
{
    public class VaccinationCardCreateDTO
    {
        public string Received { get; set; } = string.Empty;
        public string Send { get; set; } = string.Empty;
        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? ReceivedDate { get; set; }
        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? SendDate { get; set; }
        public bool Lack { get; set; }
        public string Year { get; set; } = string.Empty;
        public bool Emigration { get; set; }
        public bool Archive { get; set; }
        public string BirthType { get; set; } = string.Empty;
    }
}
