using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Its.Onix.WebApi
{
    public class ApplicationBuilderMocked : ApplicationBuilder 
    {
        public ApplicationBuilderMocked() : base(null)
        {
        }

        public IApplicationBuilder UseHttpsRedirection()
        {
            return null;
        }

        public IApplicationBuilder UseRouting()
        {
            return null;
        }

        public IApplicationBuilder UseAuthorization()
        {
            return null;
        }               

        public IApplicationBuilder UseEndpoints(Action<IEndpointRouteBuilder> configure)
        {
            return null;
        }
    }
}
