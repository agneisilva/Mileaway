using Architecture.Web;
using DotNetCore.AspNetCore;
using DotNetCore.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;

Host.CreateDefaultBuilder().UseSerilog().Run<Startup>();

namespace Architecture.Web
{
    public sealed class Startup
    {
        public void Configure(IApplicationBuilder application)
        {
            application.UseException();
            application.UseHttps();
            application.UseRouting();
            application.UseResponseCompression();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            application.UseAuthentication();
            application.UseAuthorization();
            application.UseEndpoints();
            application.UseSpa();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSecurity();
            services.AddResponseCompression();
            services.AddControllersMvcJsonOptions();
            services.AddSpa();
            services.AddContext();
            services.AddServices();
        }
    }
}
