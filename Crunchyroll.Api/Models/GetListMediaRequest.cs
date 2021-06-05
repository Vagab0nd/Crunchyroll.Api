namespace Crunchyroll.Api.Models
{
    public class GetListMediaRequest : RequestBase
    {
        public GetListMediaRequest(string locale, string sessionId, string id, bool isCollection) : base(locale, sessionId)
        {
            if (isCollection)
            {
                CollectionId = id;
            }
            else
            {
                SeriesId = id;
            }
        }

        public string CollectionId { get; set; }

        public string SeriesId { get; set; }
    }
}
