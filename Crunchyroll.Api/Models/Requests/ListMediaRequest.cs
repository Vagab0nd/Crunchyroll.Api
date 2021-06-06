namespace Crunchyroll.Api.Models.Requests
{
    public class ListMediaRequest : RequestBase
    {
        public ListMediaRequest(string locale, string sessionId, int id, bool isCollection) : base(locale, sessionId)
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
