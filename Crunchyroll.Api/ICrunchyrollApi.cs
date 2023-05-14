using Crunchyroll.Api.Models;
using Crunchyroll.Api.Models.Authentication;
using Crunchyroll.Api.Models.Watchlist;
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
        /// <summary>
        /// Login to crunchyroll Api using username (email) and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<LoginInfo> LoginWithPassword(string username, string password);

        /// <summary>
        /// Login to crunchyroll Api using refresh token. Refresh token can be obtained by copying it from the cookie named "etp_rt" in the browser on https://beta-api.crunchyroll.com/. Need to be logged into crunchyroll account.
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<LoginInfo> LoginWithRefreshToken(string refreshToken);

        /// <summary>
        /// Login to crunchyroll Api using etp_rt. It can be obtained by copying it from the cookie named "etp_rt" in the browser on https://beta-api.crunchyroll.com/. Need to be logged into crunchyroll account.
        /// </summary>
        /// <param name="etpRt"></param>
        /// <returns></returns>
        Task<LoginInfo> LoginWithEtpRt(string etpRt);

        Task<object> AddToQueue(int seriesId);

        Task<IEnumerable<WatchlistEntry>> GetWatchlist(WatchlistOptions watchlistOptions);

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

        Task<IEnumerable<Collection>> ListCollections(int seriesId);
    }
}
