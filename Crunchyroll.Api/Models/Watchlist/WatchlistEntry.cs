namespace Crunchyroll.Api.Models.Watchlist
{
    public record WatchlistEntry
    {
        /// <summary>
        /// Watchlist entry id.
        /// </summary>
        public string Id { get; init; }

        /// <summary>
        /// Has entry been added recently.
        /// </summary>
        public bool New { get; init; }

        /// <summary>
        /// Is series marked as favourite.
        /// </summary>
        public bool IsFavourite { get; init; }

        /// <summary>
        /// Has entry been ever watched.
        /// 
        public bool NeverWatched { get; init; }

        /// <summary>
        /// Has entry been fully watched.
        /// </summary>
        public bool FullyWatched { get; init; }

        public int Playhead { get; init; }

        public Series Series { get; set; }
    }
}
