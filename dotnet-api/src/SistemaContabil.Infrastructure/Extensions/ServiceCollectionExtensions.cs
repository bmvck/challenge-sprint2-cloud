using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaContabil.Domain.Services;
using SistemaContabil.Infrastructure.Configuration;

namespace SistemaContabil.Infrastructure.Extensions;

/// <summary>
/// Extensões para configuração de serviços da camada de infraestrutura
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adiciona serviços da camada de infraestrutura
    /// </summary>
    /// <param name="services">Coleção de serviços</param>
    /// <param name="configuration">Configuração da aplicação</param>
    /// <returns>Coleção de serviços configurada</returns>
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Configuração do banco de dados
        services.AddDatabaseConfiguration(configuration);

        // Registro dos serviços de domínio
        services.AddScoped<ICentroCustoService, CentroCustoService>();
        services.AddScoped<IContaService, ContaService>();
        services.AddScoped<IRegistroContabilService, RegistroContabilService>();

        return services;
    }

    /// <summary>
    /// Adiciona serviços da camada de infraestrutura para desenvolvimento
    /// </summary>
    /// <param name="services">Coleção de serviços</param>
    /// <returns>Coleção de serviços configurada</returns>
    public static IServiceCollection AddInfrastructureDevelopment(
        this IServiceCollection services)
    {
        // Configuração do banco de dados para desenvolvimento
        services.AddDatabaseDevelopment();

        return services;
    }
}
