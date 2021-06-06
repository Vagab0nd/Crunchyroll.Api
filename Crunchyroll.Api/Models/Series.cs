namespace Crunchyroll.Api.Models
{
    public class Series : IInfo
    {
        public string Class { get; set; }
        public string Description { get; set; }
        public string[] Genres { get; set; }
        public bool InQueue { get; set; }
        public Image LandscapeImage { get; set; }
        public int MediaCount { get; set; }
        public string MediaType { get; set; }
        public string Name { get; set; }
        public Image PortraitImage { get; set; }
        public string PublisherName { get; set; }
        public int Rating { get; set; }
        public int SeriesId { get; set; }
        public string Url { get; set; }
        public string Year { get; set; }
    }
}
