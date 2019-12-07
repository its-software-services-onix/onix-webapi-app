using System;
using NUnit.Framework;
using Its.Onix.WebApi.Controllers.Commons;

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
            Program.CreateHostBuilder(null);
        }     
    }
}