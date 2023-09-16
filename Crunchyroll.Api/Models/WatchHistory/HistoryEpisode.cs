using Crunchyroll.Api.Models.Common;
using System;

namespace Crunchyroll.Api.Models.WatchHistory
{
    public record HistoryEpisode
    {
        public DateTimeOffset DatePlayed { get; init; }

        public string ParentId { get; init; }

        public int Playhead { get; init; }

        public bool FullyWatched { get; init; }

        public MediaType ParentType { get; init; }
    }
}
