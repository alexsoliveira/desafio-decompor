using Desafio.Decompor.Business.Interfaces;
using Desafio.Decompor.Business.Notificacoes;
using Desafio.Decompor.Business.Services;

namespace Desafio.Decompor.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Business
            services.AddScoped<IDecomporService, DecomporService>();            
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}