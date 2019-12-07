using System;
using NUnit.Framework;

using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Core.Commons.Model;
using Its.Onix.WebApi.Forms;

namespace Its.Onix.WebApi.Controllers.Masters
{
    public class SaveMasterControllerTest : SaveControllerTest
    {
        public SaveMasterControllerTest() : base()
        {
        }

        [TestCase]
        public void SaveMasterWithFoundTest()
        {
            try
            {
                BaseModel m = SaveWithFoundTest(new SaveMasterController(Context), new SaveMasterController(Context));
                Assert.IsNotNull(m);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }            
        }

        [TestCase]
        public void SaveMasterWithNullParamTest()
        {
            try
            {
                CreateWithNullParamTest(new SaveMasterController(Context));
                Assert.Fail("Exception should be thornw here!!!");
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }            
        }

        [TestCase(999, "{MasterCode:'HelloXxx'}")]
        [TestCase(999, "")]
        [TestCase(999, null)]
        public void SaveMasterWithNotFoundTest(int id, string content)
        {
            try
            {
                FormSubmitParam prm = new FormSubmitParam();
                prm.JsonContent = content;

                if (content == null)
                {
                    prm = null;
                }

                SaveWithNotFoundTest(id, new SaveMasterController(Context), prm);
                Assert.Fail("Exception should be thrown due to no data to delete!!!");
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }     
        }        
    }
}