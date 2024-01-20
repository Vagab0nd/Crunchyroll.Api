using System.Runtime.Serialization;

namespace Crunchyroll.Api.Models.Common
{
    public enum MediaType
    {
        [EnumMember(Value = "series")]
        Series = 1,
        [EnumMember(Value = "movie_listing")]
        Movies = 2,
    }
}
