using Crunchyroll.Api.Infrastructure;
using Crunchyroll.Api.Infrastructure.Extensions;
using Crunchyroll.Api.Models.Authentication;
using Crunchyroll.Api.Models.Common;
using Crunchyroll.Api.Models.Response;
using Crunchyroll.Api.Models.WatchHistory;
using Crunchyroll.Api.Models.Watchlist;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Crunchyroll.Api
{
    public class CrunchyrollApi : ICrunchyrollApi
    {
        private const string baseUri = "https://beta-api.crunchyroll.com";
        private string locale;
        private LoginInfo loginInfo;

        public CrunchyrollApi(string locale = Locale.US)
        {
            this.SetLocale(locale);
            FlurlHttp.Clients.WithDefaults(builder =>
            {
                var settings = builder.Settings;
                var jsonSettings = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(),
                    Converters = { new JsonEnumMemberStringEnumConverter() }
                };
                settings.JsonSerializer = new DefaultJsonSerializer(jsonSettings);
                settings.UrlEncodedSerializer = new SnakeCaseUrlEncodedSerializer(true);      
#if DEBUG
                builder.OnError(this.DebugFlurlError);
#endif
            });
            
        }

        public async Task<LoginInfo> LoginWithPassword(string username, string password, CancellationToken cancellationToken = default)
        {
            return await this.Login(new LoginRequest(username, password), cancellationToken);
        }

        public async Task<LoginInfo> LoginWithRefreshToken(string refreshToken, CancellationToken cancellationToken = default)
        {
            return await this.Login(new LoginRequest(refreshToken), cancellationToken);
        }

        public void Dispose()
        {
        }

        private async Task<LoginInfo> Login(LoginRequest loginRequest, CancellationToken cancellationToken = default)
        {
            var loginInfo = await baseUri
                .AppendPathSegment("/auth/v1/token")
                .WithCrunchyrollBasicAuth()
                .PostUrlEncodedAsync(loginRequest, cancellationToken: cancellationToken)
                .ReceiveJson<LoginInfo>()
                .ConfigureAwait(false);

            this.loginInfo = loginInfo;

            return loginInfo;
        }

        public Task<LoginInfo> LoginWithEtpRt(string etpRt, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<WatchlistEntry[]> GetWatchlist(WatchlistOptions watchlistOptions = null, CancellationToken cancellationToken = default)
        {
            return await baseUri
                .AppendPathSegment($"/content/v2/discover/{this.loginInfo.AccountId}/watchlist")
                .WithOAuthBearerToken(this.loginInfo.AccessToken)
                .SetQueryParams(watchlistOptions ?? new WatchlistOptions())
                .AppendQueryParam(new { this.locale }) //TODO: Find a better way to add locale in more generic way. Middleware in flurl?
                .GetJsonAsync<Response<WatchlistEntry[]>>(cancellationToken: cancellationToken)
                .UnpackResponse()
                .ConfigureAwait(false);
        }

        public async Task<HistoryEpisode[]> GetWatchHistory(WatchHistoryOptions watchHistoryOptions = null, CancellationToken cancellationToken = default)
        {
            return await baseUri
                .AppendPathSegment($"/content/v1/watch-history/{this.loginInfo.AccountId}")
                .WithOAuthBearerToken(this.loginInfo.AccessToken)
                .SetQueryParams(watchHistoryOptions ?? new WatchHistoryOptions())
                .AppendQueryParam(new { this.locale })
                .GetJsonAsync<Response<HistoryEpisode[]>>(cancellationToken: cancellationToken)
                .UnpackResponse()
                .ConfigureAwait(false);
        }

        private async Task DebugFlurlError(FlurlCall call)
        {
            Debug.WriteLine(call.RequestBody, "RequestBody");
            Debug.WriteLine(await call.Response.ResponseMessage.Content.ReadAsStringAsync(), "ResponseMessageContent");
        }

        public void SetLocale(string locale)
        {
            if(string.IsNullOrWhiteSpace(locale))
            {
                throw new ArgumentException("Local cannot be null or empty or whitespace.", nameof(locale));
            }

            this.locale = locale;
        }
    }
}
