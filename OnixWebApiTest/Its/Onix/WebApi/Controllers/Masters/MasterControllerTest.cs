using System;
using NUnit.Framework;

using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Core.Commons.Model;
using Its.Onix.WebApi.Forms;
using Its.Onix.WebApi.Utils;

namespace Its.Onix.WebApi.Controllers.Masters
{
    public class MasterControllerTest : ControllerTestBase
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [TestCase(0)]
        public void MasterDeleteWithNotFoundTest(int id)
        {
            Assert.Pass();
        }
    }
}