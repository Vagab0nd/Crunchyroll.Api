using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;


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
            this.target = new CrunchyrollApi(TestContext.Properties["Login"].ToString(), TestContext.Properties["Pass"].ToString(), "PL-pl");
        }

        [TestMethod]
        public void Test1_Success()
        {

        }
    }
}
