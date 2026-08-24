using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CondominioSaaS.Configurations.Configs;

public static class CorsConfig
{
    public static IServiceCollection AddAppCorsPolicy(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()
                    ?? new[] { "http://localhost:3000", "https://localhost:3000", "http://localhost:4200", "http://condominio_front_:3000", "https://localhost:4200", "http://condominio_front_:4200" };

                policy.WithOrigins(allowedOrigins)
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials();
            });
        });

        return services;
    }
}