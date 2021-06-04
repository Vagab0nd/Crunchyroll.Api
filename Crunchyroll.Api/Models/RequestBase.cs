namespace Crunchyroll.Api.Models
{
    public abstract class RequestBase
    {
        protected RequestBase(string locale)
        {
            this.Locale = locale;
        }

        protected RequestBase(string locale, string sessionId)
        {
            this.Locale = locale;
            this.SessionId = sessionId;
        }

        public string ConnectivityType { get; } = "ethernet";

        public string Locale { get; }

        public string SessionId { get; }

        public string Version { get; } = "1.1.21.0";
    }
}
