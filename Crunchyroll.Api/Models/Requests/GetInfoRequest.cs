using Newtonsoft.Json;
using System;

namespace Crunchyroll.Api.Models.Requests
{
    internal class GetInfoRequest : RequestBase
    {
        public GetInfoRequest(string locale, string sessionId, int id, Type infoType) : base(locale, sessionId)
        {
            if (infoType == typeof(Media))
            {
                MediaId = id;
                Fields = this.GetMediaFields();
                return;
            }

            if (infoType == typeof(Collection))
            {
                CollectionId = id;
                return;
            }

            if (infoType == typeof(Series))
            {
                SeriesId = id;
                return;
            }
        }

        public int CollectionId { get; set; }

        public int SeriesId { get; set; }

        public int MediaId { get; set; }

        [JsonConverter(typeof(FieldsConverter))]
        public string[] Fields { get; set; }

        private string[] GetMediaFields() {
            return new[] {
                "media.availability_notes",
                "media.available",
                "media.available_time",
                "media.bif_url",
                "media.class",
                "media.clip",
                "media.collection_id",
                "media.collection_name",
                "media.created",
                "media.description",
                "media.duration",
                "media.episode_number",
                "media.free_available",
                "media.free_available_time",
                "media.free_unavailable_time",
                "media.media_id",
                "media.media_type",
                "media.name",
                "media.playhead",
                "media.premium_available",
                "media.premium_available_time",
                "media.premium_only",
                "media.premium_unavailable_time",
                "media.screenshot_image",
                "media.series_id",
                "media.series_name",
                "media.stream_data",
                "media.unavailable_time",
                "media.url"
            };
        }
    }
}
