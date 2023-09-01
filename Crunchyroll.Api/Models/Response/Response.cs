namespace Crunchyroll.Api.Models.Response
{
    public record Response<T>
    {
        public T Data { get; set; }

        public bool Error { get; set; }

        public string Code { get; set; }

        public Meta Meta { get; set; }
    }
}
