using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Its.Onix.Core.Databases;
using Its.Onix.Core.Factories;
using Its.Onix.Erp.Services;

namespace Its.Onix.WebApi.Testing
{
    public class WebHostStatupForTesting : Startup
    {
        private readonly DbCredential crd = null;

        public new IConfiguration Configuration { get; }

        public WebHostStatupForTesting(IConfiguration configuration) : base(configuration)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Its", LogLevel.Warning)
                    .AddConsole();
            });

            crd = new DbCredential("", 9999, "", "", "", "sqlite_inmem");
            Configuration = configuration;

            FactoryBusinessOperation.RegisterBusinessOperations(BusinessErpOperations.GetInstance().ExportedServicesList());
            FactoryBusinessOperation.SetLoggerFactory(loggerFactory);
        }
    }
}
