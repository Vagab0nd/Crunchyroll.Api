using Newtonsoft.Json;
using System;

namespace Crunchyroll.Api
{
    internal class FieldsConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
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
