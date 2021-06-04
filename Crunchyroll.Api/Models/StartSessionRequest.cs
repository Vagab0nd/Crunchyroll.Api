namespace Crunchyroll.Api.Models
{
    public class StartSessionRequest: RequestBase
    {
        public StartSessionRequest(string locale) : base(locale, string.Empty)
        {
        }
    }
}
