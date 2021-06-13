using Newtonsoft.Json;

namespace Crunchyroll.Api.Models.Requests
{
    public class ListCollectionsRequest : RequestBase
    {
        public ListCollectionsRequest(string locale, string sessionId, int seriesId) : base(locale, sessionId)
        {
            this.SeriesId = seriesId;
        }

        public int SeriesId { get; set; }
    }
}
