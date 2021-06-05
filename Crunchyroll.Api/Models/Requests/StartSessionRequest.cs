namespace Crunchyroll.Api.Models.Requests
{
    public class StartSessionRequest : RequestBase
    {
        public StartSessionRequest(string locale, string deviceId, string deviceType, string accessToken) : base(locale)
        {
            DeviceId = deviceId;
            DeviceType = deviceType;
            AccessToken = accessToken;
        }

        public string AccessToken { get; }

        public string DeviceId { get; }

        public string DeviceType { get; }
    }
}
