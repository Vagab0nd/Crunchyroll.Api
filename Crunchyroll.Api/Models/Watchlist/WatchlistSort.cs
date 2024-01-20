using System.Runtime.Serialization;

namespace Crunchyroll.Api.Models.Watchlist
{
    public enum WatchlistSort
    {
        [EnumMember(Value = "date_updated")]
        Updated = 1,
        [EnumMember(Value = "date_watched")]
        Watched = 2,
        [EnumMember(Value = "date_added")]
        Added = 3,
        [EnumMember(Value = "alphabetical")]
        Alphabetical = 4
    }
}
