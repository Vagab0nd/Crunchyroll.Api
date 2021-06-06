namespace Crunchyroll.Api.Models
{
    public class StreamData
    {
        public string HardsubLang { get; set; }

        public string AudioLang { get; set; }

        public string Format { get; set; }

        public Stream[] Streams { get; set; }

        public int Playhead { get; set; }
    }
}
