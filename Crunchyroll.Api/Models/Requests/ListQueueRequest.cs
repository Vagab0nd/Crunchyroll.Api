using Newtonsoft.Json;

namespace Crunchyroll.Api.Models.Requests
{
    public class ListQueueRequest : RequestBase
    {
        public ListQueueRequest(MediaType mediaTypes, string locale, string sessionId) : base(locale, sessionId)
        {
            MediaTypes = mediaTypes;
        }

        [JsonConverter(typeof(FlagConverter))]
        public MediaType MediaTypes { get; set; }

        public string[] Fields { get; set; } = new[]
        {
            "image.full_url",
            "image.fwide_url",
            "image.fwidestar_url",
            "image.height",
            "image.large_url",
            "image.medium_url",
            "image.small_url",
            "image.thumb_url",
            "image.wide_url",
            "image.widestar_url",
            "image.width",
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
            "media.url",
            "last_watched_media",
            "last_watched_media_playhead",
            "most_likely_media",
            "most_likely_media_playhead",
            "ordering",
            "playhead",
            "queue_entry_id",
            "series",
            "series.class",
            "series.collection_count",
            "series.description",
            "series.genres",
            "series.in_queue",
            "series.landscape_image",
            "series.media_count",
            "series.media_type",
            "series.name",
            "series.portrait_image",
            "series.publisher_name",
            "series.rating",
            "series.series_id",
            "series.url",
            "series.year"
        };
    }
}
