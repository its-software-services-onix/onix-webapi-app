using System;
using Microsoft.AspNetCore.Mvc;
using Its.Onix.Core.Databases;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Core.Factories;

namespace Its.Onix.WebApi.Controllers.Commons
{
    public class OnixDeleteController : OnixControllerBase
    {
        public OnixDeleteController(BaseDbContext ctx, string api, string pk, Type t) : base (ctx, api, pk, t)
        {
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var opr = (ManipulationOperation) FactoryBusinessOperation.CreateBusinessOperationObject(ApiName);

            BaseModel m = GetModel(id, "");
            BaseModel response = opr.Apply(m);
            var result = new JsonResult(response);
            
            return result;
        }
    }   
}
