using System;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.WebApi.Forms;

namespace Its.Onix.WebApi.Controllers.CompanyProfiles
{
    public class GetCompanyProfileListControllerTest : GetListControllerTest
    {
        [TestCase]
        public void GetCompanyProfileListWithFoundTest()
        {
            try
            {
                GetListWithFoundTest(new SaveCompanyProfileController(Context), new GetCompanyProfileListController(Context));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }            
        }

        [TestCase]
        public void GetCompanyProfileListNullParamTest()
        {
            try
            {
                GetListByParamTest(new SaveCompanyProfileController(Context), new GetCompanyProfileListController(Context), null);
                Assert.Fail("Expected exception because passing null QueryRequestParam!!!");
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            } 
        }        

        [TestCase("{}")]
        public void GetCompanyProfileListParamTest(string content)
        {
            FormSubmitParam param = new FormSubmitParam();
            param.JsonContent = content;

            JsonResult returnObj = GetListByParamTest(new SaveCompanyProfileController(Context), new GetCompanyProfileListController(Context), param);
            var value = returnObj.Value;

            Assert.IsInstanceOf(typeof(QueryResponseParam), value);

            int total = (value as QueryResponseParam).TotalRecord;
            Assert.AreEqual(1, total, "Expected number of item returned to be NOT zero!!!");
        } 

        [TestCase]
        public void GetCompanyProfileListWithNotFoundTest()
        {
            JsonResult returnObj = GetListWithNotFoundTest(new GetCompanyProfileListController(Context));
            var value = returnObj.Value;

            Assert.IsInstanceOf(typeof(QueryResponseParam), value);

            int total = (value as QueryResponseParam).TotalRecord;
            Assert.AreEqual(0, total, "Expected number of item returned to be zero!!!");
        } 
    }
}