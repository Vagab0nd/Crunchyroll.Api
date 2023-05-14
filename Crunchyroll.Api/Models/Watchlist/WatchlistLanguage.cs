using Crunchyroll.Api.Infrastructure;
namespace Crunchyroll.Api.Models.Watchlist
{
    public enum WatchlistLanguage
    {
        [StringValue("subbed")]
        Subbed = 1,
        [StringValue("dubbed")]
        Dubbed = 2
    }
}
