using System.Runtime.Serialization;
namespace Crunchyroll.Api.Models.Watchlist
{
    public enum WatchlistLanguage
    {
        [EnumMember(Value = "subbed")]
        Subbed = 1,
        [EnumMember(Value = "dubbed")]
        Dubbed = 2
    }
}
