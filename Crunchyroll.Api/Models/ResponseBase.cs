namespace Crunchyroll.Api.Models
{
    internal class ResponseBase
    {
        public object Data { get; set; }

        public bool Error { get; set; }

        public string Code { get; set; }
    }
}
