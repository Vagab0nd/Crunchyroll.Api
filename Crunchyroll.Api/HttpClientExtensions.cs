using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crunchyroll.Api
{
    internal static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostFormUrlEncoded<TResult>(
            this HttpClient httpClient, string requestUri, IDictionary<string, string> postData)
        {
            var content = new FormUrlEncodedContent(postData);
                content.Headers.Clear();
            content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            var response = await httpClient.PostAsync(requestUri, content);
            return response;
        }
    }
}
