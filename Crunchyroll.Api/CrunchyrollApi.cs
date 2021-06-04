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
            this.InitApi(username, password).GetAwaiter().GetResult();
        }

        private async Task InitApi(string username, string password)
        {
            var session = await this.StartSession();
            this.sessionId = session.SessionId;
            var login = await this.Login(username, password);
        }

        private async Task<LoginInfo> Login(string email, string password)
        {
            var uri = new Uri("/login");
            var respone = await this.httpClientWrapper.DoAsync(c => c.PostAsJsonAsync(uri, new LoginRequest(this.locale, this.sessionId, email, password)));
            return await this.GetDataFromResponse<LoginInfo>(respone);
        }

        private async Task<SessionInfo> StartSession()
        {
            var uri = new Uri("/start_session");
            var respone = await this.httpClientWrapper.DoAsync(c => c.PostAsJsonAsync(uri, new StartSessionRequest(this.locale) {
            }));
            return await this.GetDataFromResponse<SessionInfo>(respone);
        }


        public void Dispose()
        {
            //TODO: logout
        }

        public Task GetInfo()
        {
            throw new NotImplementedException();
        }

        public Task ListQueue(MediaType mediaType = MediaType.Default)
        {
            throw new NotImplementedException();
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

        public Task AddToQueue()
        {
            throw new NotImplementedException();
        }

        public Task GetListMedia()
        {
            throw new NotImplementedException();
        }

        public Task GetListSeries()
        {
            throw new NotImplementedException();
        }

        public Task GetListLocales()
        {
            throw new NotImplementedException();
        }

        public Task SetLog()
        {
            throw new NotImplementedException();
        }

        public Task SearchSeries()
        {
            throw new NotImplementedException();
        }
    }
}
