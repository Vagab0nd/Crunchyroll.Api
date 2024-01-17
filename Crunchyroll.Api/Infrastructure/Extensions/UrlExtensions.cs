using Flurl;
using Flurl.Http;

namespace Crunchyroll.Api.Infrastructure.Extensions
{
    internal static class UrlExtensions
    {
        private const string authorizationHeaderValue = "Basic b2VkYXJteHN0bGgxanZhd2ltbnE6OWxFaHZIWkpEMzJqdVY1ZFc5Vk9TNTdkb3BkSnBnbzE=";

        public static IFlurlRequest WithCrunchyrollBasicAuth(this Url url)
        {
            return url.WithHeader("Authorization", authorizationHeaderValue);
        }
    }
}
