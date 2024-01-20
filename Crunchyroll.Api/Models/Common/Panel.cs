namespace Crunchyroll.Api.Models.Common
{
    public record Panel {

        public string Title { get; init; }

        public string PromoTitle { get; init; }

        public string PromoDescription { get; init;}

        public string Slug { get; init; }

        public string StreamsLink { get; init; }

        public string ChannelId { get; init; }

        public string Description { get; init; }

        public string LinkedResourceKey { get; init; }

        public string SlugTitle { get; init; }

        public string RecentAudioLocale { get; init; }

        public string Type { get; init; }

        public Images Images { get; init; }

        //EpisodeMetadata
    }
}
