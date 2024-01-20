using Crunchyroll.Api.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Crunchyroll.Api.Infrastructure
{
    internal sealed class ImageArrayConverter : JsonConverter<Image[]>
    {
        public override Image[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            var imageArray = new List<Image[]>();
            foreach (JsonElement element in doc.RootElement.EnumerateArray())
            {
                var images = JsonSerializer.Deserialize<Image[]>(element.GetRawText(), options);
                imageArray.Add(images);
            }
            return imageArray.SelectMany(ia => ia).ToArray();
        }

        public override void Write(Utf8JsonWriter writer, Image[] value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
