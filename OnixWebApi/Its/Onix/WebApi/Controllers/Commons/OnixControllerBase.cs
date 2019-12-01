using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Databases;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;

namespace Its.Onix.WebApi.Controllers.Commons
{
    public class OnixControllerBase : ControllerBase
    {
        private readonly string apiName;
        private readonly string pkName;
        private readonly Type modelType;

        public OnixControllerBase(BaseDbContext ctx, string api)
        {
            apiName = api;
            FactoryBusinessOperation.SetDatabaseContext(ctx);
        }

        public OnixControllerBase(BaseDbContext ctx, string api, string pk, Type t)
        {
            pkName = pk;
            modelType = t;

            apiName = api;
            FactoryBusinessOperation.SetDatabaseContext(ctx);
        }

        [HttpGet]
        public virtual JsonResult Get()
        {
            var opr = (GetListOperation) FactoryBusinessOperation.CreateBusinessOperationObject(apiName);

            QueryRequestParam qrp = new QueryRequestParam();
            var response = opr.Apply(qrp);

            var result = new JsonResult(response);
            return result;
        }

        [HttpGet("{id}")]
        public virtual JsonResult Get(string pk, int id)
        {
            var opr = (GetInfoOperation) FactoryBusinessOperation.CreateBusinessOperationObject(apiName);

            BaseModel m = (BaseModel) Activator.CreateInstance(modelType);

            PropertyInfo propInfo = modelType.GetProperty(pkName);
            propInfo.SetValue(m, id, null);

            var response = opr.Apply(m);

            var result = new JsonResult(response);
            return result;
        }
    }   
}
