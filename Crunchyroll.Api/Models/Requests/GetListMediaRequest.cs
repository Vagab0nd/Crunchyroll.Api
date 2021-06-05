namespace Crunchyroll.Api.Models.Requests
{
    public class GetListMediaRequest : RequestBase
    {
        public GetListMediaRequest(string locale, string sessionId, int id, bool isCollection) : base(locale, sessionId)
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

        public int CollectionId { get; set; }

        public int SeriesId { get; set; }
    }
}
