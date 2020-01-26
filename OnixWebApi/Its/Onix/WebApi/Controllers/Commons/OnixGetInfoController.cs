using System;
using Microsoft.AspNetCore.Mvc;

using Its.Onix.Core.Databases;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Core.Factories;

namespace Its.Onix.WebApi.Controllers.Commons
{
    public class OnixGetInfoController : OnixControllerBase
    {
        public OnixGetInfoController(BaseDbContext ctx, string api, string pk, Type t) : base (ctx, api, pk, t)
        {
        }

        [HttpGet("{id}")]
        public virtual JsonResult GetInfo(int id)
        {
            var opr = (GetInfoOperation) FactoryBusinessOperation.CreateBusinessOperationObject(ApiName);

            BaseModel m = GetModel(id, "");
            var response = opr.Apply(m);
            var result = new JsonResult(response);

            return result;
        }
    }   
}
