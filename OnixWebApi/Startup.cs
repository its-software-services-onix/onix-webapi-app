using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Its.Onix.Core.Databases;
using Its.Onix.Core.Factories;
using Its.Onix.Erp.Databases;
using Its.Onix.Erp.Services;

using Newtonsoft.Json;

namespace Its.Onix.WebApi
{
    public class Startup
    {
        private readonly DbCredential crd = null;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Its", LogLevel.Warning)
                    .AddConsole();
            });

            string host = Environment.GetEnvironmentVariable("ONIX_ERP_DB_HOST");
            string dbname = Environment.GetEnvironmentVariable("ONIX_ERP_DB_NAME");
            string user = Environment.GetEnvironmentVariable("ONIX_ERP_DB_USER");
            string password = Environment.GetEnvironmentVariable("ONIX_ERP_DB_PASSWORD");
            crd = new DbCredential(host, 5432, dbname, user, password, "pgsql");

            Configuration = configuration;

            FactoryBusinessOperation.RegisterBusinessOperations(BusinessErpOperations.GetInstance().ExportedServicesList());
            FactoryBusinessOperation.SetLoggerFactory(loggerFactory);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<BaseDbContext>(ctx =>
            {
                var context = new OnixErpDbContext(crd);
                return context;
            });

            services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Formatting = Formatting.Indented;
            });

            //services.AddMvc(o => o.InputFormatters.Insert(0, new RawRequestBodyFormatter()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
