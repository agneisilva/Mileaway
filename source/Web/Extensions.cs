using Architecture.Application;
using Architecture.Database;
using Architecture.Model.AppSettings;
using DotNetCore.AspNetCore;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using DotNetCore.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Architecture.Web
{
    public static class Extensions
    {
        public static void AddContext(this IServiceCollection services)
        {
            var connectionString = services.GetConnectionString(nameof(Context));
            services.AddContext<Context>(options => options.UseSqlServer(connectionString));
            services.AddUnitOfWork<Context>();
        }

        public static void AddSecurity(this IServiceCollection services)
        {
            services.AddHash();
            services.AddJsonWebToken(Guid.NewGuid().ToString(), TimeSpan.FromHours(12));
            services.AddAuthenticationJwtBearer();
        }

        public static void AddJwtConfiguration(this IApplicationBuilder application)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddFileExtensionContentTypeProvider();
            services.AddClassesInterfaces(typeof(IUsuarioService).Assembly);
            services.AddClassesInterfaces(typeof(IUsuarioRepository).Assembly);
        }

        public static void AddSpa(this IServiceCollection services)
        {
            services.AddSpaStaticFiles("Frontend/dist");
        }

        public static void UseSpa(this IApplicationBuilder application)
        {
            application.UseSpaAngular("Frontend", "start", "http://localhost:4200");
        }

        public static void AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
        }
    }
}
