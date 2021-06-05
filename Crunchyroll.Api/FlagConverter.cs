using Newtonsoft.Json;
using System;
using System.Linq;

namespace Crunchyroll.Api
{
    public class FlagConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            var flags = value.ToString()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(f => $"\"{f}\"")
                .Select(f => f.ToLowerInvariant());

            writer.WriteRawValue(string.Join("|", flags));
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
