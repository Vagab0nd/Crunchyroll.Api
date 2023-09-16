using Crunchyroll.Api.Infrastructure;

namespace Crunchyroll.Api.Models.Common
{
    public enum MediaType
    {
        [StringValue("series")]
        Series = 1,
        [StringValue("movie_listing")]
        Movies = 2,
    }
}
