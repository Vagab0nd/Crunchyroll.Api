namespace Crunchyroll.Api.Models
{
    public class LoginInfo
    {
        public string Auth { get; set; }

        public string Expires { get; set; }

        public User User { get; set; }
    }
}
