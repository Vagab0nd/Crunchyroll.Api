using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Crunchyroll.Api.Models.Requests
{
    internal record LoginRequest
    {
        public LoginRequest(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.GrantType = GrantType.Password;
        }

        public LoginRequest(string refreshToken)
        {
            this.RefreshToken = refreshToken;
            this.GrantType = GrantType.RefreshToken;
        }

        public string Username { get; }

        public string Password { get; }

        [JsonConverter(typeof(StringEnumConverter), true)]
        public GrantType GrantType { get; }

        public string RefreshToken { get; }

        public string Scope { get; } = "OfflineAccess";
    }
}
