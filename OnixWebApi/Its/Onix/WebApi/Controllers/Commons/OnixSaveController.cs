using System;
using Microsoft.AspNetCore.Mvc;
using Its.Onix.Core.Databases;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Core.Factories;
using Its.Onix.WebApi.Forms;

namespace Its.Onix.WebApi.Controllers.Commons
{
    public class OnixSaveController : OnixControllerBase
    {
        public OnixSaveController(BaseDbContext ctx, string api, string pk, Type t) : base (ctx, api, pk, t)
        {
        }

        [HttpPost]
        //Use POST method with the Get* operations with parameters to prevent the issue when deploy to Google Cloud Run
        //This is an example of issue - HTTP/2 stream 1 was not closed cleanly: PROTOCOL_ERROR (err 1)
        public virtual JsonResult CreateWithParam([FromForm] FormSubmitParam prm = null)
        {
            object response = null;

            string content = "";
            if ((prm != null) && (!String.IsNullOrEmpty(prm.JsonContent)))
            {
                content = prm.JsonContent;
            }

            var opr = FactoryBusinessOperation.CreateBusinessOperationObject(ApiName);

            BaseModel m = GetModel(null, content);
            response = (opr as ManipulationOperation).Apply(m);

            var result = new JsonResult(response);
            return result;
        }

        [HttpPut("{id}")]
        public virtual JsonResult Update(int id, [FromForm] FormSubmitParam prm = null)
        {
            var opr = (ManipulationOperation) FactoryBusinessOperation.CreateBusinessOperationObject(ApiName);

            string content = "";
            if ((prm != null) && (!String.IsNullOrEmpty(prm.JsonContent)))
            {
                content = prm.JsonContent;
            }

            BaseModel m = GetModel(id, content);
            var response = opr.Apply(m);
            var result = new JsonResult(response);

            return result;
        }   
    }   
}
