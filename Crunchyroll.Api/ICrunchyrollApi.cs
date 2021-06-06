using Crunchyroll.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crunchyroll.Api
{
    /// <summary>
    /// https://github.com/CloudMax94/crunchyroll-api/wiki/Api
    /// </summary>
    public interface ICrunchyrollApi : IDisposable
    {

        Task<object> AddToQueue(int seriesId);

        Task<IEnumerable<QueueEntry>> ListQueue(MediaType mediaType = MediaType.Anime | MediaType.Drama);

        Task<T> GetInfo<T>(int id) where T : IInfo;

        /// <summary>
        /// fetches information about media
        /// </summary>
        /// <param name="id">series_id or collection_id</param>
        /// <returns></returns>
        Task<IEnumerable<Media>> ListMedia(int id, bool isCollection = false);

        Task<object> ListSeries();

        Task<object> ListLocales();

        Task<object> SetLog();

        /// <summary>
        /// autocomplete
        /// </summary>
        /// <returns></returns>
        Task<object> SearchSeries(string query, MediaType mediaType = MediaType.Anime | MediaType.Drama);
    }
}
