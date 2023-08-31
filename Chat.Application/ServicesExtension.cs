using Chat.Application.Hubs;
using Chat.Application.Interfaces.Hubs;
using Chat.Application.Interfaces.Services;
using Chat.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Application
{
    public static class ServicesExtension
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddSignalR(options =>
                options.EnableDetailedErrors = true
            );

            services.AddScoped<IActiveUserServices, ActiveUserServices>();

            return services;
        }
    }
}
