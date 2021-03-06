using System;
using NUnit.Framework;

using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Core.Commons.Model;

namespace Its.Onix.WebApi.Controllers.Masters
{
    public class GetMasterInfoControllerTest : GetInfoControllerTest
    {
        [TestCase]
        public void GetMasterInfoWithFoundTest()
        {
            try
            {
                GetInfoWithFoundTest(new SaveMasterController(Context), new GetMasterInfoController(Context));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }            
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(999)]
        [TestCase(1)]
        public void GetMasterInfoWithNotFoundTest(int id)
        {
            try
            {
                BaseModel returnObj = GetInfoWithNotFoundTest(id, new GetMasterInfoController(Context));

                //No data if id > 0 then should be null
                Assert.IsNull(returnObj, "Expected null result!!!");
            }
            catch (Exception e)
            {
                Assert.LessOrEqual(id, 0, "ID should be less than or equal zero when exception happened!!! [{0}]", e);
            }     
        } 
    }
}