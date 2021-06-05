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
        public async Task Test1_Success()
        {
            var x = await this.target.GetListMedia("682821", false);

        }
    }
}
