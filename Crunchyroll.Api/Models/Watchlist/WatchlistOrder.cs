using Crunchyroll.Api.Infrastructure;

namespace Crunchyroll.Api.Models.Watchlist
{
    public enum WatchlistOrder
    {
        [StringValue("desc")]
        Newest = 1,
        [StringValue("asc")]
        Oldest = 2,
    }
}
