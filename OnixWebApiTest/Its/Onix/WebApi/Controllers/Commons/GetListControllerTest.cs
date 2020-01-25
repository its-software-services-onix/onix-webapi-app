using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using Its.Onix.WebApi.Forms;
using Its.Onix.Core.Commons.Model;
using Its.Onix.WebApi.Utils;

namespace Its.Onix.WebApi.Controllers.Commons
{
	public class GetListControllerTest : ControllerTestBase
	{
        protected JsonResult GetListWithFoundTest(OnixSaveController createCtrl, OnixGetListController getListCtrl)
        {
            FormSubmitParam prm = new FormSubmitParam();

            BaseModel createdObj = (BaseModel)Activator.CreateInstance(createCtrl.ModelType);
            TestUtils.PopulateDummyPropValues(createdObj, createCtrl.PkFieldName);
            prm.JsonContent = JsonConvert.SerializeObject(createdObj, Formatting.Indented);

            createCtrl.CreateWithParam(prm);

            JsonResult getResult = getListCtrl.Get();
            return getResult;
        }

        protected JsonResult GetListWithNotFoundTest(OnixGetListController getListCtrl)
        {
            JsonResult getResult = getListCtrl.Get();
            return getResult;
        }   

        protected JsonResult GetListByParamTest(OnixSaveController createCtrl, OnixGetListController getListCtrl, FormSubmitParam param)
        {
            FormSubmitParam prm = new FormSubmitParam();

            BaseModel createdObj = (BaseModel)Activator.CreateInstance(createCtrl.ModelType);
            TestUtils.PopulateDummyPropValues(createdObj, createCtrl.PkFieldName);
            prm.JsonContent = JsonConvert.SerializeObject(createdObj, Formatting.Indented);

            createCtrl.CreateWithParam(prm);

            JsonResult getResult = getListCtrl.GetWithParam(param);
            return getResult;
        }        
    }
}
