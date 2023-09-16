namespace Crunchyroll.Api.Models.WatchHistory
{
    public record WatchHistoryOptions
    {
        public int Page { get; init; } = 1;

        public int PageSize { get; init; } = 100;
    }
}
