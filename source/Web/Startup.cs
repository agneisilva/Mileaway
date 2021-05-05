using Architecture.Web;
using DotNetCore.AspNetCore;
using DotNetCore.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder().UseSerilog().Run<Startup>();

namespace Architecture.Web
{
    public sealed class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseException();
            application.UseHttps();
            application.UseRouting();
            application.UseResponseCompression();
            application.AddJwtConfiguration();
            application.UseAuthentication();
            application.UseAuthorization();
            application.UseEndpoints();
            application.UseSpa();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppSettings(Configuration);

            services.AddSecurity();
            services.AddResponseCompression();
            services.AddControllersMvcJsonOptions();
            services.AddSpa();
            services.AddContext();
            services.AddServices();
        }
    }
}
