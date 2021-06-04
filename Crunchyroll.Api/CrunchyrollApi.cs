using Crunchyroll.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crunchyroll.Api
{
    public class CrunchyrollApi : ICrunchyrollApi
    {
        private const string baseUri = "https://api.crunchyroll.com/";
        private const string apiVersion = "1.1.21.0";
        private const string apiToken = "LNDJgOit5yaRIWN";
        private const string deviceType = "com.crunchyroll.windows.desktop";

        private readonly string deviceId = Guid.NewGuid().ToString();
        private readonly string locale;

        private string sessionId;

        private readonly CrunchyrollHttpClientWrapper httpClientWrapper;
        private readonly DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };

        public CrunchyrollApi(string username, string password, string locale)
        {
            var cultureInfo = new CultureInfo(locale);
            this.locale = cultureInfo.Name.Replace("-", string.Empty);
            this.httpClientWrapper = new CrunchyrollHttpClientWrapper(baseUri);
            InitApi(username, password).GetAwaiter().GetResult();
        }

        private async Task InitApi(string username, string password)
        {
            var session = await StartSession();
            this.sessionId = session.SessionId;
            var login = await Login(username, password);
        }

        private async Task<LoginInfo> Login(string email, string password)
        {
            var uri = "/login.0.json";
            var respone = await this.httpClientWrapper.DoAsync(c => c.PostAsJsonAsync(uri, new LoginRequest(this.locale, this.sessionId, email, password)));
            return await GetDataFromResponse<LoginInfo>(respone);
        }

        private async Task<SessionInfo> StartSession()
        {
            var uri = "/start_session.0.json";
            var respone = await this.httpClientWrapper.DoAsync(c => c.PostAsJsonAsync(uri, new StartSessionRequest(this.locale)));
            return await this.GetDataFromResponse<SessionInfo>(respone);
        }


        public void Dispose()
        {
            //TODO: logout
        }

        private async Task<T> GetDataFromResponse<T>(HttpResponseMessage httpResponse)
        {
            var response = await httpResponse.Content.ReadAsAsync<ResponseBase>();
            return JsonConvert.DeserializeObject<T>(response.Data.ToString(), new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
        }

        public Task<string> GetListMedia()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetListSeries()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetListLocales()
        {
            throw new NotImplementedException();
        }

        public Task<string> SetLog()
        {
            throw new NotImplementedException();
        }

        public Task<string> AddToQueue(int seriesId)
        {
            throw new NotImplementedException();
        }

        public Task<string> ListQueue(MediaType mediaType)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetInfo()
        {
            throw new NotImplementedException();
        }

        public Task<string> SearchSeries(string query, MediaType mediaType = MediaType.Default)
        {
            throw new NotImplementedException();
        }
    }
}
