using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Prosolve.MicroService.Identification.Entities.Users;

using Sharpdev.SDK.API;
using Sharpdev.SDK.Infrastructure.Integrations;
using Sharpdev.SDK.Infrastructure.Repositories;

namespace Prosolve.MicroService.Identification.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigurationAuthorization(new AuthorizationOptions());

            services.AddSingleton<IIdentityService, IdentityService>();
            services.AddSingleton<IEntityRepository<IUser>, UserEntityRepository>();
            services.AddSingleton<IIntegrateBus, VirtualIntegrateBus>();
            services.AddSingleton<IIdentityService, IdentityService>();

            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging();

            //настройки поддержки разных версий API функций
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseAuthentication();
           // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
