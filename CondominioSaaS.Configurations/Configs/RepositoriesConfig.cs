using CondominioSaaS.Domain.Repositories;
using CondominioSaaS.Domain.Repositories.Auth;
using CondominioSaaS.Infrastructure.Repositories;
using CondominioSaaS.Infrastructure.Repositories.Auth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CondominioSaaS.Configurations.Configs;

public static class RepositoriesConfig
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.TryAddScoped<IAuthUserRepository, AuthUserRepository>();
        services.TryAddScoped<IEmpresaRepository, EmpresaRepository>();
        services.TryAddScoped<IImovelRepository, ImovelRepository>();
        services.TryAddScoped<IMoradorRepository, MoradorRepository>();

        return services;
    }
}