using Crunchyroll.Api.Infrastructure;

namespace Crunchyroll.Api.Models.Watchlist
{
    public enum WatchlistSort
    {
        [StringValue("date_updated")]
        Updated = 1,
        [StringValue("date_watched")]
        Watched = 2,
        [StringValue("date_added")]
        Added = 3,
        [StringValue("alphabetical")]
        Alphabetical = 4
    }
}
