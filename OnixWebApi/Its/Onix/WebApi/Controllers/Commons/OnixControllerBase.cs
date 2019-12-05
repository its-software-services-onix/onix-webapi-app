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
        private BaseModel model = null;

        private readonly string apiName;
        private readonly string pkName;
        private readonly Type modelType;

        public string ApiName
        {
            get 
            {
                return apiName;
            }
        }

        public Type ModelType
        {
            get 
            {
                return modelType;
            }
        }     

        public string PkFieldName
        {
            get 
            {
                return pkName;
            }
        }

        public void SetModel(BaseModel m)
        {
            model = m;
        }

        public OnixControllerBase(BaseDbContext ctx, string api, string pk, Type t)
        {
            pkName = pk;
            modelType = t;

            apiName = api;
            FactoryBusinessOperation.SetDatabaseContext(ctx);
        }

        public BaseModel GetModel(int? id, string content)
        {
            if (model != null)
            {
                return model;
            }

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
