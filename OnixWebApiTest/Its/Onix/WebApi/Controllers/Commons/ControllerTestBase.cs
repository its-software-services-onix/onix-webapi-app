using NUnit.Framework;
using Its.Onix.Erp.Databases;
using Its.Onix.Core.Databases;
using Its.Onix.Core.Factories;
using Its.Onix.Erp.Services;

namespace Its.Onix.WebApi.Controllers.Commons
{
	public class ControllerTestBase
	{
        private OnixErpDbContext ctx = null; 

        protected OnixErpDbContext Context
        {
            get 
            {
                return ctx;
            }
        }
        
        public ControllerTestBase()
        {
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            FactoryBusinessOperation.ClearRegisteredItems();
            FactoryBusinessOperation.RegisterBusinessOperations(BusinessErpOperations.GetInstance().ExportedServicesList());

            CreateOnixDbContext();
        }
        
        [OneTimeTearDown]
        public void Teardown()
        {
        }

        protected OnixErpDbContext CreateOnixDbContext()
        {            
            DbCredential crd = new DbCredential("", 9999, "", "", "", "sqlite_inmem");
            ctx = new OnixErpDbContext(crd);
            ctx.Database.EnsureCreated();

            FactoryBusinessOperation.SetDatabaseContext(ctx);
            return ctx;
        }
    }
}
