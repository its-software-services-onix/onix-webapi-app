using NUnit.Framework;
using Moq;

namespace Its.Onix.WebApi
{
    public class ProgramTest
    {        
        public ProgramTest()
        {
        }

        [TestCase]
        public void ProgramRunningTest()
        {
            //Program.StartupClass = typeof(StartupMocked);
            //Program.Main(null);
            Program.CreateHostBuilder(null, typeof(StartupMocked));
        }     
    }
}