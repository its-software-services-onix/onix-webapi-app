using NUnit.Framework;
using Microsoft.Extensions.Configuration;

using Moq;

namespace Its.Onix.WebApi
{
    public class StartupTest
    {
        public StartupTest()
        {
        }

        [TestCase]
        public void StartupRunningTest()
        {
            IConfiguration config = new Mock<IConfiguration>().Object;
            Startup startup = new Startup(config);

            Assert.AreEqual(config, startup.Configuration);
        }     
    }
}