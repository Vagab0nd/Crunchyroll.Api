using System.Runtime.Serialization;

namespace Crunchyroll.Api.Models.Watchlist
{
    public enum WatchlistOrder
    {
        [EnumMember(Value = "desc")]
        Newest = 1,
        [EnumMember(Value = "asc")]
        Oldest = 2,
    }
}
