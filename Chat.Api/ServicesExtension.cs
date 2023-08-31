using Chat.Api.Middlewares;
using System.Reflection;

namespace Chat.Api
{
    public static class ServicesExtension
    {
        public static IServiceCollection ApiServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowClientOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:3001")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });

            services.AddTransient<GlobalErrorHandlerMiddleware>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
