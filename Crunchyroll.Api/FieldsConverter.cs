using Newtonsoft.Json;
using System;

namespace Crunchyroll.Api
{
    public class FieldsConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            var fields = value as string[];
            writer.WriteRawValue($"\"{string.Join(",", fields)}\"");
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
