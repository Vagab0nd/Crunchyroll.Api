namespace Crunchyroll.Api.Models.Requests
{
    public abstract class RequestBase
    {
        protected RequestBase(string locale)
        {
            Locale = locale;
        }

        protected RequestBase(string locale, string sessionId)
        {
            Locale = locale;
            SessionId = sessionId;
        }

        public string ConnectivityType { get; } = "ethernet";

        public string Locale { get; }

        public string SessionId { get; }

        public string Version { get; } = "1.1.21.0";
    }
}
