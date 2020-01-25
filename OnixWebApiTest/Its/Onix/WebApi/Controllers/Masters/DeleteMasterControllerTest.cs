using System;
using NUnit.Framework;
using Its.Onix.WebApi.Controllers.Commons;

namespace Its.Onix.WebApi.Controllers.Masters
{
    public class DeleteMasterControllerTest : DeleteControllerTest
    {
        public DeleteMasterControllerTest() : base()
        {
        }

        [TestCase]
        public void DeleteMasterWithFoundTest()
        {
            try
            {
                DeleteWithFoundTest(new SaveMasterController(Context), new DeleteMasterController(Context));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }            
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(1)]
        public void DeleteMasterWithNotFoundTest(int id)
        {
            try
            {
                DeleteWithNotFoundTest(id, new DeleteMasterController(Context));
                Assert.Fail("Exception should be thrown due to no data to delete!!!");
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }     
        }        
    }
}