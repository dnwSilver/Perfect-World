using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Prosolve.MicroService.Identity.Entities.Users;

using Sharpdev.SDK.API;
using Sharpdev.SDK.Layers.Infrastructure.Integrations;
using Sharpdev.SDK.Layers.Infrastructure.Repositories;

namespace Prosolve.MicroService.Identity.API
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
            services.AddSingleton<IRepository<IUser>, UserRepository>();
            services.AddSingleton<IIntegrateBus, VirtualIntegrateBus>();
            services.AddSingleton<IIdentityService, IdentityService>();

            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging();

            //настройки версионирования
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            app.UseAuthentication();
           // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
