using Flurl.Http;
using Flurl.Http.Configuration;
using Invedia.Core.ConfigUtils;
using Invedia.DI;
using Invedia.Web.Middlewares.HttpContextMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using XProject.Core.Configs;
using XProject.Core.Constants;
using XProject.Core.Utils;
using XProject.Repository.Infrastructure;

namespace XProject.WebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "XProject.WebApi", Version = "v1" });
            });

            services.AddApplicationInsightsTelemetry();
            services.AddHealthChecks();
            services.AddSystemSetting(Configuration.GetSection<SystemSettingModel>("SystemSetting"));
            services.AddInvediaHttpContext();
            services.AddDataProtection();

            var connectionString = SystemHelper.AppDb;
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddControllers().AddNewtonsoftJson().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);

            // Auto Register Dependency Injection
            services.AddDI();
            services.PrintServiceAddedToConsole();
            // Flurl Config
            FlurlHttp.Configure(config =>
            {
                config.JsonSerializer = new NewtonsoftJsonSerializer(Formattings.JsonSerializerSettings);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swagger = Configuration.GetValue("UseSwagger", false);
            if (swagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.DefaultModelsExpandDepth(-1);
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "XProject v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSerilogRequestLogging();

            // System Setting
            app.UseSystemSetting();

            app.UseInvediaHttpContext();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("health");
                endpoints.MapControllerRoute(
                    name: "area", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}