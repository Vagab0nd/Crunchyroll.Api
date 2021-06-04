using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Crunchyroll.Api
{
    internal class CrunchyrollHttpClientWrapper : IDisposable
    {
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(5, 5);

        private readonly HttpClient client;

        public CrunchyrollHttpClientWrapper(string baseUri)
        {
            this.client = new HttpClient() { BaseAddress = new Uri(baseUri.TrimEnd('/', '\\')) };
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
