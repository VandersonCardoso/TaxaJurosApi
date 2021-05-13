using Microsoft.Extensions.DependencyInjection;
using TaxaJurosApi.Core.Interfaces;
using TaxaJurosApi.Services;

namespace TaxaJurosApi.IoC
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<ITaxaService, TaxaService>();
            #endregion

            return services;
        }
    }
}
