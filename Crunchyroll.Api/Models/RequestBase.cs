namespace Crunchyroll.Api.Models
{
    public abstract class RequestBase
    {
        protected RequestBase(string locale, string sessionId)
        {
            this.Locale = locale;
            this.SessionId = sessionId;
        }

        public string ConnectivityType { get; } = "Ethernet";

        public string Locale { get; set; }

        public string SessionId { get; set; }

        public string Version { get; } = "0";
    }
}
