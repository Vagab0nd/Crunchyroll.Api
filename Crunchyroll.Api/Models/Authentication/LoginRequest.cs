using Crunchyroll.Api.Infrastructure;
using System.Runtime.Serialization;

namespace Crunchyroll.Api.Models.Authentication
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

        public GrantType GrantType { get; }

        public string RefreshToken { get; }

        public string Scope { get; } = "OfflineAccess";
    }
}
