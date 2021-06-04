using System;

namespace Crunchyroll.Api.Models
{
    [Flags]
    public enum MediaType
    {
        Anime = 0,
        Drama = 1,

        Default = Anime | Drama
    }
}
