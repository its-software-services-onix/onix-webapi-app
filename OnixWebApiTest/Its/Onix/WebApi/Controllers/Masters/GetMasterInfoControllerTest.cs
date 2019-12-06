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
    public class GetMasterInfoControllerTest : ControllerTestBase
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [TestCase]
        public void GetMasterWithFoundTest()
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

                GetMasterInfoController getInfoCtrl = new GetMasterInfoController(Context);
                JsonResult getResult = getInfoCtrl.GetInfo(newID);
                BaseModel returnObj = (BaseModel) getResult.Value;

                Assert.IsNotNull(returnObj, "Expected not null result!!!");
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
                GetMasterInfoController getInfoCtrl = new GetMasterInfoController(Context);
                JsonResult getResult = getInfoCtrl.GetInfo(id);
                BaseModel returnObj = (BaseModel) getResult.Value;

                //No data if id > 0 then should be null
                Assert.IsNull(returnObj, "Expected null result!!!");
            }
            catch (Exception e)
            {
                if (id > 0)
                {
                    //Exception should throw only when id <= 0
                    Assert.Fail("No exception should be thrown even there is no data to get!!! [{0}]", e);
                }
            }     
        } 
    }
}