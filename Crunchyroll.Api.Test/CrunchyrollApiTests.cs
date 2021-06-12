using Crunchyroll.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Linq;
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
        public async Task ListMedia_should_return_series_media()
        {
            var response = await this.target.ListMedia(272617);

            Assert.IsTrue(response.Count() > 0);

        }

        [TestMethod]
        public async Task ListQueue_should_return_queue()
        {
            var response = await this.target.ListQueue(MediaType.Anime);

            Assert.IsTrue(response.Count() > 0);
        }

        [TestMethod]
        public async Task GetInfo_should_return_series_info()
        {
            var response = await this.target.GetInfo<Series>(272617);

            Assert.IsTrue(response != null);

        }

        [TestMethod]
        public async Task GetInfo_should_return_media_info()
        {
            var response = await this.target.GetInfo<Media>(789680);

            Assert.IsTrue(response != null);

        }

        [TestMethod]
        public async Task ListCollections_should_return_collections()
        {
            var response = await this.target.ListCollections(272617);

            Assert.IsTrue(response != null);

        }
    }
}
