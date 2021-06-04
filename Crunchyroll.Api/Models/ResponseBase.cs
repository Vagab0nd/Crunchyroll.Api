namespace Crunchyroll.Api.Models
{
    internal class ResponseBase
    {
        public string Data { get; set; }

        public bool Error { get; set; }

        public string Code { get; set; }
    }
}
