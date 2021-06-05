using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Crunchyroll.Api.Models
{
    public class Media
    {
        /// <summary>
        /// Information regarding the medias availability
        /// </summary>
        public string AvailabilityNotes { get; set; }

        /// <summary>
        /// Whether or not the media is available
        /// </summary>
        public bool Available { get; set; }

        /// <summary>
        /// When the media becomes/became available
        /// </summary>
        public DateTimeOffset AvailableTime { get; set; }

        public string BifUrl { get; set; }

        public string Class { get; set; }

        /// <summary>
        /// Whether or not the media is a clip
        /// </summary>
        public bool Clip { get; set; }

        /// <summary>
        /// The ID of the collection the media belongs to
        /// </summary>
        public int CollectionId { get; set; }

        /// <summary>
        /// The name of the collection the media belongs to
        /// </summary>
        public string CollectionName { get; set; }

        /// <summary>
        /// A timestamp of when the media was created
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// A description of the media
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The duration of the media in seconds
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// The episode number
        /// </summary>
        public string EpisodeNumber { get; set; }

        /// <summary>
        /// Whether or not the media is available for free
        /// </summary>
        public bool FreeAvailable { get; set; }

        /// <summary>
        /// When the media becomes/became available for free
        /// </summary>
        public DateTimeOffset FreeAvailableTime { get; set; }

        /// <summary>
        /// When the media becomes/became unavailable for free
        /// </summary>
        public DateTimeOffset FreeUnavailableTime { get; set; }

        /// <summary>
        /// The ID of the media
        /// </summary>
        public int MediaId { get; set; }

        /// <summary>
        /// What type the media is
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public MediaType MediaType { get; set; }

        /// <summary>
        /// The name of the media
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The playhead of the media in seconds
        /// </summary>
        public int Playhead { get; set; }

        /// <summary>
        /// Whether or not the media is available for premium members
        /// </summary>
        public bool PremiumAvailable { get; set; }

        /// <summary>
        /// When the media becomes/became available for premium members
        /// </summary>
        public DateTimeOffset PremiumAvailableTime { get; set; }

        /// <summary>
        /// Whether or not the media is available to premium members only
        /// </summary>
        public bool PremiumOnly { get; set; }

        /// <summary>
        /// When the media becomes/became unavailable for premium members
        /// </summary>
        public DateTimeOffset PremiumUnavailableTime { get; set; }

        /// <summary>
        /// A screenshot of the media
        /// </summary>
        public Object ScreenshotImage { get; set; }

        /// <summary>
        /// The ID of the series the media belongs to
        /// </summary>
        public int SeriesId { get; set; }

        /// <summary>
        /// The name of the series the media belongs to
        /// </summary>
        public string SeriesName { get; set; }

        public Object StreamData { get; set; }

        /// <summary>
        /// When the media becomes/became available
        /// </summary>
        public DateTimeOffset UnavailableTime { get; set; }

        /// <summary>
        /// The URL to the media on crunchyroll.com
        /// </summary>
        public string Url { get; set; }
    }
}
