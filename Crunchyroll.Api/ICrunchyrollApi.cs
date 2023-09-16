using Crunchyroll.Api.Models.Authentication;
using Crunchyroll.Api.Models.Common;
using Crunchyroll.Api.Models.Response;
using Crunchyroll.Api.Models.WatchHistory;
using Crunchyroll.Api.Models.Watchlist;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Crunchyroll.Api
{
    /// <summary>
    /// Crunchyroll Api
    /// </summary>
    public interface ICrunchyrollApi : IDisposable
    {
        /// <summary>
        /// Login to crunchyroll Api using username (email) and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<LoginInfo> LoginWithPassword(string username, string password, CancellationToken cancellationToken = default);

        /// <summary>
        /// Login to crunchyroll Api using refresh token. Refresh token can be obtained by copying it from the cookie named "etp_rt" in the browser on https://beta-api.crunchyroll.com/. Need to be logged into crunchyroll account.
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<LoginInfo> LoginWithRefreshToken(string refreshToken, CancellationToken cancellationToken = default);

        /// <summary>
        /// Login to crunchyroll Api using etp_rt. It can be obtained by copying it from the cookie named "etp_rt" in the browser on https://beta-api.crunchyroll.com/. Need to be logged into crunchyroll account.
        /// </summary>
        /// <param name="etpRt"></param>
        /// <returns></returns>
        Task<LoginInfo> LoginWithEtpRt(string etpRt, CancellationToken cancellationToken = default);

        Task<WatchlistEntry[]> GetWatchlist(WatchlistOptions watchlistOptions = null, CancellationToken cancellationToken = default);

        Task<HistoryEpisode[]> GetWatchHistory(WatchHistoryOptions watchHistoryOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Set locale for crunchyroll media.
        /// </summary>
        /// <param name="locale">See <see cref="Locale"/> for available values.</param>
        void SetLocale(string locale);
    }
}
