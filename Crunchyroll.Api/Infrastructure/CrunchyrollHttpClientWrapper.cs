using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Crunchyroll.Api.Infrastructure
{
    internal sealed class CrunchyrollHttpClientWrapper : IDisposable
    {
        private static readonly SemaphoreSlim semaphore = new(5, 5);

        private readonly HttpClient client;

        public CrunchyrollHttpClientWrapper(string baseUri)
        {
            this.client = new HttpClient { BaseAddress = new Uri(baseUri.TrimEnd('/', '\\')) };
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "aHJobzlxM2F3dnNrMjJ1LXRzNWE6cHROOURteXRBU2Z6QjZvbXVsSzh6cUxzYTczVE1TY1k=");
        }

        public async Task<HttpResponseMessage> DoAsync(Func<HttpClient, Task<HttpResponseMessage>> requestFunc)
        {
            await semaphore.WaitAsync();
            try
            {
                return await requestFunc(this.client);
            }
            finally
            {
                semaphore.Release();
            }
        }

        public void Dispose()
        {
            this.client.Dispose();
        }
    }
}
