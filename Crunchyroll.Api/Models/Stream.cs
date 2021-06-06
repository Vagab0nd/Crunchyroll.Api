using System;

namespace Crunchyroll.Api.Models
{
    public class Stream
    {
        public string Quality { get; set; }

        public DateTimeOffset Expires { get; set; }

        public string Url { get; set; }
    }
}
