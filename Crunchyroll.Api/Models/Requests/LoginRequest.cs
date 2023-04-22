using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Crunchyroll.Api.Models.Requests
{
    internal record LoginRequest
    {
        public LoginRequest(string username, string password, GrantType grantType)
        {
            this.Username = username;
            this.Password = password;
            GrantType = grantType;
        }

        public string Username { get; }

        public string Password { get; }

        [JsonConverter(typeof(StringEnumConverter), true)]
        public GrantType GrantType { get; }

        public string Scope { get; } = "OfflineAccess";
    }
}
