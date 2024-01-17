using Crunchyroll.Api.Models.Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Crunchyroll.Api.Test
{
    [TestClass]
    public class CrunchyrollApiTests
    {
        private ICrunchyrollApi target;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public async Task _Initialize()
        {
            this.target = new CrunchyrollApi();
            var response = await this.target.LoginWithPassword(this.TestContext.Properties["Login"]?.ToString(), this.TestContext.Properties["Pass"]?.ToString());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetWatchlist_should_return_watchlist()
        {
            //act
            var response = await this.target.GetWatchlist(new Models.Watchlist.WatchlistOptions());

            //assert
            response.Should().NotBeNullOrEmpty();
        }

    }
}
