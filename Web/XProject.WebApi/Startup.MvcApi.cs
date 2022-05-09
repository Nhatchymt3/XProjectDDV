using XProject.WebApi.Filters.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace XProject.WebApi
{
    public static class StartupMvcApi
    {
        #region Services

        public static IServiceCollection AddMvcApi(this IServiceCollection services)
        {
            // Validation Filters

            services.AddScoped<ApiValidationActionFilterAttribute>();
            return services;
        }

        #endregion Services
    }
}