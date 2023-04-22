namespace Crunchyroll.Api.Models
{
    public record LoginInfo
    {
        public string AccessToken { get; init; }

        public string AccountId { get; init; }

        public string Country { get; init; }

        public int ExpiresIn { get; init; }

        public string RefreshToken { get; init; }

        public string Scope { get; init; }

        //TODO: create enum?
        public string TokenType { get; init; }
    }
}
