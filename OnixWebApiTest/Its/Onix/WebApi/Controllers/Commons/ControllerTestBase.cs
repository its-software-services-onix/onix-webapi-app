using Its.Onix.Erp.Databases;
using Its.Onix.Core.Databases;
using Its.Onix.Core.Factories;
using Its.Onix.Erp.Services;

namespace Its.Onix.WebApi.Controllers.Commons
{
	public class ControllerTestBase
	{
        public ControllerTestBase()
        {
            FactoryBusinessOperation.RegisterBusinessOperations(BusinessErpOperations.GetInstance().ExportedServicesList());
        }

        protected OnixErpDbContext CreateOnixDbContext()
        {
            OnixErpDbContext ctx = null;

            DbCredential crd = new DbCredential("", 9999, "", "", "", "sqlite_inmem");
            ctx = new OnixErpDbContext(crd);
            ctx.Database.EnsureCreated();

            FactoryBusinessOperation.SetDatabaseContext(ctx);
            return ctx;
        }        
    }
}
