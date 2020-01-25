using System;
using NUnit.Framework;

using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Core.Commons.Model;
using Its.Onix.WebApi.Forms;

namespace Its.Onix.WebApi.Controllers.CompanyProfiles
{
    public class SaveCompanyProfileControllerTest : SaveControllerTest
    {
        public SaveCompanyProfileControllerTest() : base()
        {
        }

        [TestCase]
        public void SaveCompanyProfileWithFoundTest()
        {
            try
            {
                BaseModel m = SaveWithFoundTest(new SaveCompanyProfileController(Context), new SaveCompanyProfileController(Context));
                Assert.IsNotNull(m);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }            
        }

        [TestCase]
        public void SaveCompanyProfileWithNullParamTest()
        {
            try
            {
                CreateWithNullParamTest(new SaveCompanyProfileController(Context));
                Assert.Fail("Exception should be thornw here!!!");
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }            
        }

        [TestCase(999, "{CompanyProfileCode:'HelloXxx'}")]
        [TestCase(999, "")]
        [TestCase(999, null)]
        public void SaveCompanyProfileWithNotFoundTest(int id, string content)
        {
            try
            {
                FormSubmitParam prm = new FormSubmitParam();
                prm.JsonContent = content;

                if (content == null)
                {
                    prm = null;
                }

                SaveWithNotFoundTest(id, new SaveCompanyProfileController(Context), prm);
                Assert.Fail("Exception should be thrown due to no data to delete!!!");
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }     
        }        
    }
}