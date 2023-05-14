namespace Crunchyroll.Api.Models.Watchlist
{
    public record SimpleWatchlistEntry
    {
        /// <summary>
        /// Watchlist entry id.
        /// </summary>
        public string Id { get; init; }

        /// <summary>
        /// Is series marked as favourite.
        /// </summary>
        public bool IsFavourite { get; init; }
    }
}
