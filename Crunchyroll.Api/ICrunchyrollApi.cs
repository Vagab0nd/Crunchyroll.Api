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

        /// <summary>
        /// fetches information about media
        /// </summary>
        /// <param name="id">series_id or collection_id</param>
        /// <returns></returns>
        Task<string> GetListMedia(string id, bool isCollection);

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
