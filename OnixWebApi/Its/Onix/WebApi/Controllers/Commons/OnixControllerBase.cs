using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Databases;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;

using Newtonsoft.Json;

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

        private BaseModel GetModel(int? id, string content)
        {
            BaseModel m = (BaseModel) Activator.CreateInstance(modelType);
            if (!String.IsNullOrEmpty(content))
            {
                m = (BaseModel) JsonConvert.DeserializeObject(content, modelType);
            }
            
            PropertyInfo propInfo = modelType.GetProperty(pkName);
            propInfo.SetValue(m, id, null);

            return m;
        }        

        [HttpGet]
        public virtual JsonResult Get([FromBody] string content)
        {
            var opr = (GetListOperation) FactoryBusinessOperation.CreateBusinessOperationObject(apiName);

            var qrp = new QueryRequestParam();
            if (!String.IsNullOrEmpty(content))
            {
                qrp = (QueryRequestParam) JsonConvert.DeserializeObject<QueryRequestParam>(content);
            }
            var response = opr.Apply(qrp);

            var result = new JsonResult(response);
            return result;
        }

        [HttpGet("{id}")]
        public virtual JsonResult GetInfo(int id)
        {
            var opr = (GetInfoOperation) FactoryBusinessOperation.CreateBusinessOperationObject(apiName);

            BaseModel m = GetModel(id, "");
            var response = opr.Apply(m);
            var result = new JsonResult(response);

            return result;
        }

        [HttpDelete("{id}")]
        public virtual JsonResult Delete(int id)
        {
            var opr = (ManipulationOperation) FactoryBusinessOperation.CreateBusinessOperationObject(apiName);

            BaseModel m = GetModel(id, "");
            var response = opr.Apply(m);
            var result = new JsonResult(response);

            return result;
        }

        [HttpPost]
        public virtual JsonResult Create([FromBody] string content)
        {
            var opr = (ManipulationOperation) FactoryBusinessOperation.CreateBusinessOperationObject(apiName);

            BaseModel m = GetModel(null, content);
            var response = opr.Apply(m);
            var result = new JsonResult(response);

            return result;
        }    

        [HttpPut("{id}")]
        public virtual JsonResult Update([FromBody] string content, int id)
        {
            var opr = (ManipulationOperation) FactoryBusinessOperation.CreateBusinessOperationObject(apiName);

            BaseModel m = GetModel(id, content);
            var response = opr.Apply(m);
            var result = new JsonResult(response);

            return result;
        }                        
    }   
}
