using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using Its.Onix.WebApi.Forms;
using Its.Onix.Core.Commons.Model;
using Its.Onix.WebApi.Utils;

namespace Its.Onix.WebApi.Controllers.Commons
{
	public class DeleteControllerTest : ControllerTestBase
	{
        protected void DeleteWithFoundTest(OnixSaveController createCtrl, OnixDeleteController delCtrl)
        {
            FormSubmitParam prm = new FormSubmitParam();

            BaseModel createdObj = (BaseModel)Activator.CreateInstance(createCtrl.ModelType);
            TestUtils.PopulateDummyPropValues(createdObj, createCtrl.PkFieldName);
            prm.JsonContent = JsonConvert.SerializeObject(createdObj, Formatting.Indented);

            JsonResult result = createCtrl.CreateWithParam(prm);
            createdObj = (BaseModel)result.Value;
            int newID = (int)TestUtils.GetPropertyValue(createdObj, createCtrl.PkFieldName);

            delCtrl.SetModel(createdObj);
            delCtrl.Delete(-1); //Not use the ID       
        }

        protected void DeleteWithNotFoundTest(int id, OnixDeleteController delCtrl)
        {
            delCtrl.Delete(id);            
        }   
    }
}
