using NUnit.Framework;
using Its.Onix.Erp.Databases;
using Its.Onix.Core.Databases;
using Its.Onix.Core.Factories;
using Its.Onix.Erp.Services;
/*
using Its.Onix.Erp.Utils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Its.Onix.WebApi.Testing;
using Its.Onix.Core.Commons.Model;
*/

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
        
/*        
        private IHostBuilder hostBuilder;
        private IHost host;

        protected IHost WebHost
        {
            get 
            {
                return host;
            }
        }
*/
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
/*
        protected IHostBuilder CreateHostBuilderForTesting(string[] args)
        {
            IHostBuilder builder = Host.CreateDefaultBuilder();
            builder.ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<WebHostStatupForTesting>();
                });

            return builder;
        }        
*/        
    }
}
