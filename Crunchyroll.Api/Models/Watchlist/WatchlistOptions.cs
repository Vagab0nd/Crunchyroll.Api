namespace Crunchyroll.Api.Models.Watchlist
{
    public record WatchlistOptions
    {
        public WatchlistOrder Order { get; init; } = WatchlistOrder.Newest;

        public WatchlistSort? SortBy { get; init; }

        public WatchlistLanguage? Language { get; init; }

        public bool OnlyFavourites { get; init; }
    }
}
