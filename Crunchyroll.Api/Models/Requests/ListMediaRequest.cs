﻿namespace Crunchyroll.Api.Models.Requests
{
    public class ListMediaRequest : RequestBase
    {
        public ListMediaRequest(string locale, string sessionId, int id, bool isCollection) : base(locale, sessionId)
        {
            if (isCollection)
            {
                this.CollectionId = id;
            }
            else
            {
                this.SeriesId = id;
            }
        }

        public int CollectionId { get; set; }

        public int SeriesId { get; set; }
    }
}
