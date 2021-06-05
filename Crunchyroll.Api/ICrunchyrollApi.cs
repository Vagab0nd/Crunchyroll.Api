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

        Task<object> AddToQueue(int seriesId);

        Task<object> ListQueue(MediaType mediaType = MediaType.Anime | MediaType.Drama);

        Task<object> GetInfo();

        /// <summary>
        /// fetches information about media
        /// </summary>
        /// <param name="id">series_id or collection_id</param>
        /// <returns></returns>
        Task<object> GetListMedia(string id, bool isCollection);

        Task<object> GetListSeries();

        Task<object> GetListLocales();

        Task<object> SetLog();

        /// <summary>
        /// autocomplete
        /// </summary>
        /// <returns></returns>
        Task<object> SearchSeries(string query, MediaType mediaType = MediaType.Anime | MediaType.Drama);
    }
}
