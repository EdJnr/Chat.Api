using Chat.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Infrastructure
{
    public static class ServicesExtension
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
