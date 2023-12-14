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
                return null; // Jeśli wartość w JSON jest pusta, zwróć null dla DateTime?
            }

            if (DateTime.TryParse(strValue, out DateTime dateTimeValue))
            {
                return DateTime.SpecifyKind(dateTimeValue, DateTimeKind.Utc); // Ustaw wartość DateTime z odpowiednią wartością Kind
            }
            else
            {
                throw new JsonException(); // Rzuć wyjątek w przypadku problemów z parsowaniem wartości do DateTime
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
