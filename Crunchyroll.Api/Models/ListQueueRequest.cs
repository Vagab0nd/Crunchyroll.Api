using Newtonsoft.Json;

namespace Crunchyroll.Api.Models
{
    public class ListQueueRequest : RequestBase
    {
        public ListQueueRequest(MediaType mediaTypes, string locale, string sessionId) : base(locale, sessionId)
        {
            this.MediaTypes = mediaTypes;
        }

        [JsonConverter(typeof(FlagConverter))]
        public MediaType MediaTypes { get; set; }

        public string[] Fields { get; set; } = new[] { "series", "media.media_id" };
    }
}
