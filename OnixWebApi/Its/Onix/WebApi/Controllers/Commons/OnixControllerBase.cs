using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Databases;
using Its.Onix.Core.Commons.Model;

using Newtonsoft.Json;

namespace Its.Onix.WebApi.Controllers.Commons
{
    public class OnixControllerBase : ControllerBase
    {
        private readonly string apiName;
        private readonly string pkName;
        private readonly Type modelType;

        protected string ApiName
        {
            get 
            {
                return apiName;
            }
        }

        public OnixControllerBase(BaseDbContext ctx, string api, string pk, Type t)
        {
            pkName = pk;
            modelType = t;

            apiName = api;
            FactoryBusinessOperation.SetDatabaseContext(ctx);
        }

        protected BaseModel GetModel(int? id, string content)
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
    }   
}
