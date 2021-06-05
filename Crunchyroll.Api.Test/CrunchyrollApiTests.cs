using Crunchyroll.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Crunchyroll.Api.Test
{
    [TestClass]
    public class CrunchyrollApiTests
    {
        private ICrunchyrollApi target;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void CrunchyrollApiTestsInit()
        {
            this.target = new CrunchyrollApi(TestContext.Properties["Login"]?.ToString(), TestContext.Properties["Pass"]?.ToString(), "en-US");
        }

        [TestMethod]
        public async Task GetListMedia_should_return_series_info()
        {
            var response = (await this.target.GetListMedia(272199, false)).ToString();

            Assert.IsFalse(string.IsNullOrWhiteSpace(response));

        }

        [TestMethod]
        public async Task ListQueue_should_return_queue()
        {
            var response = (await this.target.ListQueue(MediaType.Anime)).ToString();

            Assert.IsFalse(string.IsNullOrWhiteSpace(response));
        }
    }
}
