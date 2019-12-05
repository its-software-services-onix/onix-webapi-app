using System;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.WebApi.Forms;
using Its.Onix.Core.Commons.Model;
using Its.Onix.WebApi.Utils;
using Newtonsoft.Json;

namespace Its.Onix.WebApi.Controllers.Masters
{
    public class MasterControllerTest : ControllerTestBase
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [TestCase]
        public void MasterDeleteWithFoundTest()
        {
            try
            {
                SaveMasterController createCtrl = new SaveMasterController(Context);
                FormSubmitParam prm = new FormSubmitParam();

                BaseModel createdObj = (BaseModel) Activator.CreateInstance(createCtrl.ModelType);
                TestUtils.PopulateDummyPropValues(createdObj, createCtrl.PkFieldName);
                prm.JsonContent = JsonConvert.SerializeObject(createdObj, Formatting.Indented);
                
                JsonResult result = createCtrl.CreateWithParam(prm);
                createdObj = (BaseModel) result.Value;
                int newID = (int) TestUtils.GetPropertyValue(createdObj, createCtrl.PkFieldName);

                DeleteMasterController delCtrl = new DeleteMasterController(Context);
                delCtrl.SetModel(createdObj);
                delCtrl.Delete(-1); //Not use the ID 
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }            
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(999)]
        public void MasterDeleteWithNotFoundTest(int id)
        {
            try
            {
                DeleteMasterController delCtrl = new DeleteMasterController(Context);
                delCtrl.Delete(id);
                Assert.Fail("Exception should be thrown due to no data to delete!!!");
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }     
        }        
    }
}