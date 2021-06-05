using System;

namespace Crunchyroll.Api.Models
{
    public class Collection
    {
        public string AvailabilityNotes { get; set; }
        public string Class { get; set; }
        public int CollectionId { get; set; }
        public bool Complete { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Description { get; set; }
        public Image LandscapeImage { get; set; }
        public string MediaType { get; set; }
        public string Name { get; set; }
        public Image PortraitImage { get; set; }
        public int Season { get; set; }
        public int SeriesId { get; set; }
    }
}
