namespace Crunchyroll.Api.Models
{
    public class StartSessionRequest: RequestBase
    {
        public StartSessionRequest(string locale, string deviceId, string deviceType, string accessToken): base(locale)
        {
            this.DeviceId = deviceId;
            this.DeviceType = deviceType;
            this.AccessToken = accessToken;
        }

        public string AccessToken { get; }

        public string DeviceId { get; }

        public string DeviceType { get; }
    }
}
