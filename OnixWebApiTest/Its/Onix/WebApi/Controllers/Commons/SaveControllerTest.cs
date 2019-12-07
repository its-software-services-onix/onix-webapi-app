using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using Its.Onix.WebApi.Forms;
using Its.Onix.Core.Commons.Model;
using Its.Onix.WebApi.Utils;

namespace Its.Onix.WebApi.Controllers.Commons
{
	public class SaveControllerTest : ControllerTestBase
	{
        protected BaseModel SaveWithFoundTest(OnixSaveController createCtrl, OnixSaveController updateCtrl)
        {
            FormSubmitParam prm = new FormSubmitParam();

            BaseModel createdObj = (BaseModel)Activator.CreateInstance(createCtrl.ModelType);
            TestUtils.PopulateDummyPropValues(createdObj, createCtrl.PkFieldName);
            prm.JsonContent = JsonConvert.SerializeObject(createdObj, Formatting.Indented);

            JsonResult result = createCtrl.CreateWithParam(prm);
            createdObj = (BaseModel)result.Value;
            int newID = (int)TestUtils.GetPropertyValue(createdObj, createCtrl.PkFieldName);

            updateCtrl.SetModel(createdObj);
            var returnObj = updateCtrl.Update(newID, prm);
            BaseModel model = (BaseModel) returnObj.Value;

            return model;
        }

        protected BaseModel SaveWithNotFoundTest(int id, OnixSaveController saveCtrl, FormSubmitParam prm)
        {
            JsonResult getResult = saveCtrl.Update(id, prm);
            BaseModel returnObj = (BaseModel)getResult.Value;

            return returnObj;
        }   

        protected BaseModel CreateWithNullParamTest(OnixSaveController createCtrl)
        {
            createCtrl.CreateWithParam(null);
            return null;
        }        
    }
}
