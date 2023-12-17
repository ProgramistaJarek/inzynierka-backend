using System.Text.Json;
using System.Text.Json.Serialization;

namespace backend.Utilities
{
    public class NullableDateTimeConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string strValue = reader.GetString();
            if (string.IsNullOrEmpty(strValue))
            {
                return null;
            }

            if (DateTime.TryParse(strValue, out DateTime dateTimeValue))
            {
                return DateTime.SpecifyKind(dateTimeValue, DateTimeKind.Utc);
            }
            else
            {
                throw new JsonException();
            }
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value == null || value == DateTime.MinValue)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(value.Value);
            }
        }
    }
}
