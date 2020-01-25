using System;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.WebApi.Forms;

namespace Its.Onix.WebApi.Controllers.Masters
{
    public class GetMasterListControllerTest : GetListControllerTest
    {
        [TestCase]
        public void GetMasterListWithFoundTest()
        {
            try
            {
                GetListWithFoundTest(new SaveMasterController(Context), new GetMasterListController(Context));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }            
        }

        [TestCase]
        public void GetMasterListNullParamTest()
        {
            try
            {
                GetListByParamTest(new SaveMasterController(Context), new GetMasterListController(Context), null);
                Assert.Fail("Expected exception because passing null QueryRequestParam!!!");
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            } 
        }        

        [TestCase("{}")]
        public void GetMasterListParamTest(string content)
        {
            FormSubmitParam param = new FormSubmitParam();
            param.JsonContent = content;

            JsonResult returnObj = GetListByParamTest(new SaveMasterController(Context), new GetMasterListController(Context), param);
            var value = returnObj.Value;

            Assert.IsInstanceOf(typeof(QueryResponseParam), value);

            int total = (value as QueryResponseParam).TotalRecord;
            Assert.AreEqual(1, total, "Expected number of item returned to be NOT zero!!!");
        } 

        [TestCase]
        public void GetMasterListWithNotFoundTest()
        {
            JsonResult returnObj = GetListWithNotFoundTest(new GetMasterListController(Context));
            var value = returnObj.Value;

            Assert.IsInstanceOf(typeof(QueryResponseParam), value);

            int total = (value as QueryResponseParam).TotalRecord;
            Assert.AreEqual(0, total, "Expected number of item returned to be zero!!!");
        } 
    }
}