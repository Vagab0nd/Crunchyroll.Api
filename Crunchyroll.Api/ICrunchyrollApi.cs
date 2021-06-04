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

        Task<string> AddToQueue(int seriesId);

        Task<string> ListQueue(MediaType mediaType = MediaType.Default);

        Task<string> GetInfo();

        Task<string> GetListMedia();

        Task<string> GetListSeries();

        Task<string> GetListLocales();

        Task<string> SetLog();

        /// <summary>
        /// autocomplete
        /// </summary>
        /// <returns></returns>
        Task<string> SearchSeries(string query, MediaType mediaType = MediaType.Default);
    }
}
