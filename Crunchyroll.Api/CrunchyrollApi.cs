using Crunchyroll.Api.Infrastructure;
using Crunchyroll.Api.Infrastructure.Extensions;
using Crunchyroll.Api.Models;
using Crunchyroll.Api.Models.Authentication;
using Crunchyroll.Api.Models.Common;
using Crunchyroll.Api.Models.Response;
using Crunchyroll.Api.Models.WatchHistory;
using Crunchyroll.Api.Models.Watchlist;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Diagnostics;
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
            this.locale = locale;
            FlurlHttp.Configure(settings =>
            {
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    ObjectCreationHandling = ObjectCreationHandling.Replace,
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }                    
                };
                settings.JsonSerializer = new NewtonsoftJsonSerializer(jsonSettings);
                settings.UrlEncodedSerializer = new SnakeCaseUrlEncodedSerializer(true);
#if DEBUG
                settings.OnErrorAsync = this.DebugFlurlError;
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
                .PostUrlEncodedAsync(loginRequest, cancellationToken)
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
                .GetJsonAsync<Response<WatchlistEntry[]>>(cancellationToken)
                .UnpackResponse()
                .ConfigureAwait(false);
        }

        public async Task<HistoryEpisode[]> GetWatchHistory(WatchHistoryOptions watchHistoryOptions = null, CancellationToken cancellationToken = default)
        {
            return await baseUri
                .AppendPathSegment($"/content/v1/watch-history/{this.loginInfo.AccountId}")
                .WithOAuthBearerToken(this.loginInfo.AccessToken)
                .SetQueryParams(watchHistoryOptions ?? new WatchHistoryOptions())
                .GetJsonAsync<Response<HistoryEpisode[]>>(cancellationToken)
                .UnpackResponse()
                .ConfigureAwait(false);
        }

        private async Task DebugFlurlError(FlurlCall call)
        {
            Debug.WriteLine(call.RequestBody, "RequestBody");
            Debug.WriteLine(await call.Response.ResponseMessage.Content.ReadAsStringAsync(), "ResponseMessageContent");
        }
    }
}
