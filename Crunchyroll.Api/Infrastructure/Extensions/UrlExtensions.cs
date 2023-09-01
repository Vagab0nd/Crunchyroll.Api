using Flurl;
using Flurl.Http;

namespace Crunchyroll.Api.Infrastructure.Extensions
{
    internal static class UrlExtensions
    {
        private const string authorizationHeaderValue = "Basic aHJobzlxM2F3dnNrMjJ1LXRzNWE6cHROOURteXRBU2Z6QjZvbXVsSzh6cUxzYTczVE1TY1k=";

        public static IFlurlRequest WithCrunchyrollBasicAuth(this Url url)
        {
            return url.WithHeader("Authorization", authorizationHeaderValue);
        }
    }
}
