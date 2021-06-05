namespace Crunchyroll.Api.Models.Requests
{
    public class LoginRequest : RequestBase
    {
        public LoginRequest(string locale, string sessionId, string email, string password) : base(locale, sessionId)
        {
            Account = email;
            Password = password;
        }

        public string Account { get; set; }

        public string Password { get; set; }
    }
}
