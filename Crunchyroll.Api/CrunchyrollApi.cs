using Crunchyroll.Api.Models;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Crunchyroll.Api
{
    public class CrunchyrollApi : ICrunchyrollApi
    {
        private const string baseUri = "https://api.crunchyroll.com/";
        private const string apiVersion = "1.3.1.0";
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
        private readonly JsonSerializerSettings jsonSerializerSettings;
        private readonly JsonMediaTypeFormatter jsonMediaTypeFormatter;

        public CrunchyrollApi(string username, string password, string locale)
        {
            this.jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore
            };
            this.jsonMediaTypeFormatter =  new JsonMediaTypeFormatter { SerializerSettings = jsonSerializerSettings };

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
            var loginRequest = new LoginRequest(this.locale, this.sessionId, email, password);
            var respone = await this.httpClientWrapper.DoAsync(c => 
                c.PostFormUrlEncoded<LoginInfo>(
                    "/login.0.json", 
                    this.ObjToQueryParams(loginRequest)
                )
            );
            return await this.GetDataFromResponse<LoginInfo>(respone);
        }

        private async Task<SessionInfo> StartSession()
        {
            var startSessionRequest = new StartSessionRequest(this.locale, this.deviceId, deviceType, apiToken);
            var uri = QueryHelpers.AddQueryString("/start_session.0.json", this.ObjToQueryParams(startSessionRequest));
            var respone = await this.httpClientWrapper.DoAsync(c => c.GetAsync(uri));
            return await this.GetDataFromResponse<SessionInfo>(respone);
        }


        public void Dispose()
        {
            //TODO: logout
        }

        private async Task<T> GetDataFromResponse<T>(HttpResponseMessage httpResponse)
        {
            string req, res;
            if (httpResponse.RequestMessage.Method == HttpMethod.Post)
            {
                req = await httpResponse.RequestMessage?.Content?.ReadAsStringAsync();
            }
            res = await httpResponse.Content?.ReadAsStringAsync();

            var response = await httpResponse.Content.ReadAsAsync<ResponseBase>();            
            return JsonConvert.DeserializeObject<T>(response.Data.ToString(), this.jsonSerializerSettings);
        }

        IDictionary<string, string> ObjToQueryParams(object obj)
        {
            var json = JsonConvert.SerializeObject(obj, this.jsonSerializerSettings);
            var dict = JsonConvert.DeserializeObject<IDictionary<string, string>>(json);
            return dict;
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
