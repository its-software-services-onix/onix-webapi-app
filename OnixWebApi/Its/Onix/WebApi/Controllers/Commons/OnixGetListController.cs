using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

using Its.Onix.Core.Databases;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Core.Factories;
using Its.Onix.WebApi.Forms;

namespace Its.Onix.WebApi.Controllers.Commons
{
    public class OnixGetListController : OnixControllerBase
    {
        public OnixGetListController(BaseDbContext ctx, string api, string pk, Type t) : base (ctx, api, pk, t)
        {
        }

        [HttpPost]
        //Use POST method with the Get* operations with parameters to prevent the issue when deploy to Google Cloud Run
        //This is an example of issue - HTTP/2 stream 1 was not closed cleanly: PROTOCOL_ERROR (err 1)
        public virtual JsonResult GetWithParam([FromForm] FormSubmitParam prm = null)
        {
            object response = null;

            string content = "";
            if ((prm != null) && (!String.IsNullOrEmpty(prm.JsonContent)))
            {
                content = prm.JsonContent;
            }

            var opr = FactoryBusinessOperation.CreateBusinessOperationObject(ApiName);

            var qrp = new QueryRequestParam();
            qrp = JsonConvert.DeserializeObject<QueryRequestParam>(content);
            response = (opr as GetListOperation).Apply(qrp);

            var result = new JsonResult(response);
            return result;
        }

        [HttpGet]
        public virtual JsonResult Get()
        {
            var opr = (GetListOperation) FactoryBusinessOperation.CreateBusinessOperationObject(ApiName);

            var qrp = new QueryRequestParam();
            var response = opr.Apply(qrp);

            var result = new JsonResult(response);
            return result;
        }
    }   
}
