using System;
using NUnit.Framework;
using Its.Onix.WebApi.Controllers.Commons;

namespace Its.Onix.WebApi.Controllers.CompanyProfiles
{
    public class DeleteCompanyProfileControllerTest : DeleteControllerTest
    {
        public DeleteCompanyProfileControllerTest() : base()
        {
        }

        [TestCase]
        public void DeleteCompanyProfileWithFoundTest()
        {
            try
            {
                DeleteWithFoundTest(new SaveCompanyProfileController(Context), new DeleteCompanyProfileController(Context));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }            
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(1)]
        public void DeleteCompanyProfileWithNotFoundTest(int id)
        {
            try
            {
                DeleteWithNotFoundTest(id, new DeleteCompanyProfileController(Context));
                Assert.Fail("Exception should be thrown due to no data to delete!!!");
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }     
        }        
    }
}