using System;

namespace Crunchyroll.Api.Models.Requests
{
    internal class GetInfoRequest : RequestBase
    {
        public GetInfoRequest(string locale, string sessionId, int id, Type infoType) : base(locale, sessionId)
        {
            if (infoType == typeof(Media))
            {
                MediaId = id;
                return;
            }

            if (infoType == typeof(Collection))
            {
                CollectionId = id;
                return;
            }

            if (infoType == typeof(Series))
            {
                SeriesId = id;
                return;
            }
        }

        public int CollectionId { get; set; }

        public int SeriesId { get; set; }

        public int MediaId { get; set; }
    }
}
