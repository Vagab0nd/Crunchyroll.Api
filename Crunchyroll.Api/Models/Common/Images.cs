using Crunchyroll.Api.Infrastructure;
using System.Text.Json.Serialization;

namespace Crunchyroll.Api.Models.Common
{
    public record Images
    {
        [JsonPropertyName("thumbnail")]
        [JsonConverter(typeof(ImageArrayConverter))]
        public Image[] Thumbnails { get; init; }
    }
}
