using Microsoft.AspNetCore.Mvc;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Databases;
using Its.Onix.Erp.Businesses.Commons;

namespace Its.Onix.WebApi.Controllers.Commons
{
    public class OnixControllerBase : ControllerBase
    {
        private readonly BaseDbContext dbContext = null;
        private readonly string apiName = "";

        public OnixControllerBase(BaseDbContext ctx, string api)
        {
            apiName = api;
            dbContext = ctx;

            FactoryBusinessOperation.SetDatabaseContext(dbContext);
        }

        [HttpGet]
        public JsonResult Get()
        {
            var opr = (GetListOperation) FactoryBusinessOperation.CreateBusinessOperationObject(apiName);

            QueryRequestParam qrp = new QueryRequestParam();
            var response = opr.Apply(qrp);

            var result = new JsonResult(response);
            return result;
        }          
    }   
}
