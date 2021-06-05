using System;

namespace Crunchyroll.Api.Models
{
    public class QueueEntry
    {
        public Media LastWatchMedia { get; set; }

        public Media MostLikelyMedia { get; set; }

        public int Ordering { get; set; }

        public int QueueEntryId { get; set; }

        public int LastWatchMediaPlayhead { get; set; }

        public int MostLikelyMediaPlayhead { get; set; }

        public int Playhead { get; set; }

        public Series Series { get; set; }
    }
}
