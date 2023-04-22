using Crunchyroll.Api.Extensions;
using Crunchyroll.Api.Infrastructure;
using Crunchyroll.Api.Models;
using Crunchyroll.Api.Models.Requests;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Crunchyroll.Api
{
    public class CrunchyrollApi : ICrunchyrollApi
    {
        private const string baseUri = "https://beta-api.crunchyroll.com";
        private readonly string locale;

        private static string sessionId;

        private readonly CrunchyrollHttpClientWrapper httpClientWrapper;
        private readonly DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };
        private readonly JsonSerializerSettings jsonSerializerSettings;
        private readonly JsonMediaTypeFormatter jsonMediaTypeFormatter;

        public CrunchyrollApi()
        {
            this.jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore
            };
            this.jsonMediaTypeFormatter = new JsonMediaTypeFormatter { SerializerSettings = jsonSerializerSettings };
            this.httpClientWrapper = new CrunchyrollHttpClientWrapper(baseUri);
        }

        public async Task<LoginInfo> LoginWithPassword(string username, string password)
        {
            var loginRequest = new LoginRequest(username, password, GrantType.Password);
            var response = await this.httpClientWrapper.DoAsync(c =>
                c.PostFormUrlEncoded<LoginInfo>(
                    "/auth/v1/token",
                    ObjToQueryParams(loginRequest)
                )
            );
            //debug code below - run only in debug config
            #if DEBUG
            var requestString = await response.RequestMessage.Content.ReadAsStringAsync();
            var responseString = await response.Content.ReadAsStringAsync();
            #endif
            return await GetDataFromResponse<LoginInfo>(response);
        }

        public void Dispose()
        {
            //TODO: logout
        }

        private async Task<T> GetDataFromResponse<T>(HttpResponseMessage httpResponse)
        {
            var response = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(response, this.jsonSerializerSettings);
        }

        private IDictionary<string, string> ObjToQueryParams(object obj)
        {
            string json = JsonConvert.SerializeObject(obj, this.jsonSerializerSettings);
            var dict = JsonConvert.DeserializeObject<IDictionary<string, object>>(json);
            return dict.ToDictionary(d => d.Key, d =>
                d.Value.GetType().IsArray
                ? JsonConvert.SerializeObject(d.Value, this.jsonSerializerSettings)
                : d.Value.ToString()
            );
        }

        public async Task<IEnumerable<Media>> ListMedia(int id, bool isCollection = false)
        {
            var getListMediaRequest = new ListMediaRequest(this.locale, sessionId, id, isCollection);
            string uri = QueryHelpers.AddQueryString("/list_media.0.json", ObjToQueryParams(getListMediaRequest));
            var response = await this.httpClientWrapper.DoAsync(c => c.GetAsync(uri));
            return await GetDataFromResponse<Media[]>(response);
        }

        public Task<object> ListSeries()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Collection>> ListCollections(int seriesId)
        {
            var getListMediaRequest = new ListCollectionsRequest(this.locale, sessionId, seriesId);
            string uri = QueryHelpers.AddQueryString("/list_collections.0.json", ObjToQueryParams(getListMediaRequest));
            var response = await this.httpClientWrapper.DoAsync(c => c.GetAsync(uri));
            return await GetDataFromResponse<Collection[]>(response);
        }

        public Task<object> ListLocales()
        {
             throw new NotImplementedException();
        }

        public Task<object> SetLog()
        {
            throw new NotImplementedException();
        }

        public Task<object> AddToQueue(int seriesId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QueueEntry>> ListQueue(MediaType mediaType = MediaType.Anime | MediaType.Drama)
        {
            var listQueueRequest = new ListQueueRequest(mediaType, this.locale, sessionId);
            string uri = QueryHelpers.AddQueryString("/queue.0.json", ObjToQueryParams(listQueueRequest));
            var response = await this.httpClientWrapper.DoAsync(c => c.GetAsync(uri));
            return await GetDataFromResponse<QueueEntry[]>(response);
        }

        public async Task<T> GetInfo<T>(int id) where T : IInfo
        {
            var getInfoRequest = new GetInfoRequest(this.locale, sessionId, id, typeof(T));
            var response = await this.httpClientWrapper.DoAsync(c =>
                c.PostFormUrlEncoded<LoginInfo>(
                    "/info.0.json",
                    ObjToQueryParams(getInfoRequest)
                )
            );
            return await GetDataFromResponse<T>(response);         
        }

        public Task<object> SearchSeries(string query, MediaType mediaType = MediaType.Anime | MediaType.Drama)
        {
            throw new NotImplementedException();
        }
    }
}
