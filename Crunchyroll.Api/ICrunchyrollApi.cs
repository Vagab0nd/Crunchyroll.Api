using Crunchyroll.Api.Models;
using System;
using System.Threading.Tasks;

namespace Crunchyroll.Api
{
    /// <summary>
    /// https://github.com/CloudMax94/crunchyroll-api/wiki/Api
    /// </summary>
    public interface ICrunchyrollApi : IDisposable
    {

        Task AddToQueue();

        Task ListQueue(MediaType mediaType = MediaType.Default);

        Task GetInfo();

        Task GetListMedia();

        Task GetListSeries();

        Task GetListLocales();

        Task SetLog();

        /// <summary>
        /// autocomplete
        /// </summary>
        /// <returns></returns>
        Task SearchSeries();
    }
}
