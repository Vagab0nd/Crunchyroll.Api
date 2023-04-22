using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Crunchyroll.Api.Infrastructure
{
    internal class CrunchyrollHttpClientWrapper : IDisposable
    {
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(5, 5);

        private readonly HttpClient client;

        public CrunchyrollHttpClientWrapper(string baseUri)
        {
            client = new HttpClient { BaseAddress = new Uri(baseUri.TrimEnd('/', '\\')) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "aHJobzlxM2F3dnNrMjJ1LXRzNWE6cHROOURteXRBU2Z6QjZvbXVsSzh6cUxzYTczVE1TY1k=");
        }

        public async Task<HttpResponseMessage> DoAsync(Func<HttpClient, Task<HttpResponseMessage>> requestFunc)
        {
            await semaphore.WaitAsync();
            try
            {
                return await requestFunc(client);
            }
            finally
            {
                semaphore.Release();
            }
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
