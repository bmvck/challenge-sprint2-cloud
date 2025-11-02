using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaContabil.Domain.Interfaces;
using SistemaContabil.Infrastructure.Data;
using SistemaContabil.Infrastructure.Repositories;

namespace SistemaContabil.Infrastructure.Configuration;

/// <summary>
/// Configuração do banco de dados
/// </summary>
public static class DatabaseConfiguration
{
    /// <summary>
    /// Strings de conexão para Oracle FIAP (múltiplas opções)
    /// </summary>
    public static readonly string[] ConnectionStrings = new[]
    {
        // Opção 1: Service Name FREEPDB1 (FORMATO CORRETO)
        "Data Source=140.238.179.84:1521/FREEPDB1;User Id=appuser;Password=AppPass#2025;",
        
        // Opção 2: Service Name FREEPDB1 com timeout
        "Data Source=140.238.179.84:1521/FREEPDB1;User Id=appuser;Password=AppPass#2025;Connection Timeout=30;",
        
        // Opção 3: Formato TNS (se disponível)
        "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=140.238.179.84)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=FREEPDB1)));User Id=appuser;Password=AppPass#2025;",
        
        // Opção 4: Formato TNS com timeout
        "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=140.238.179.84)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=FREEPDB1)));User Id=appuser;Password=AppPass#2025;Connection Timeout=30;"
    };

    /// <summary>
    /// String de conexão atual (será testada)
    /// </summary>
    public static string ConnectionString => ConnectionStrings[0]; // Começa com a primeira opção

    /// <summary>
    /// Configura o Entity Framework Core para Oracle
    /// </summary>
    /// <param name="services">Coleção de serviços</param>
    /// <param name="configuration">Configuração da aplicação</param>
    /// <returns>Coleção de serviços configurada</returns>
    public static IServiceCollection AddDatabaseConfiguration(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Configuração do DbContext
        services.AddDbContext<SistemaContabilDbContext>(options =>
        {
            options.UseOracle(ConnectionString, oracleOptions =>
            {
                oracleOptions.CommandTimeout(30);
            });
        });

        // Registro dos repositórios
        services.AddScoped<ICentroCustoRepository, CentroCustoRepository>();
        services.AddScoped<IContaRepository, ContaRepository>();
        services.AddScoped<IRegistroContabilRepository, RegistroContabilRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IVendasRepository, VendasRepository>();

        return services;
    }

    /// <summary>
    /// Configura o banco de dados para desenvolvimento
    /// </summary>
    /// <param name="services">Coleção de serviços</param>
    /// <returns>Coleção de serviços configurada</returns>
    public static IServiceCollection AddDatabaseDevelopment(
        this IServiceCollection services)
    {
        services.AddDbContext<SistemaContabilDbContext>(options =>
        {
            options.UseOracle(ConnectionString, oracleOptions =>
            {
                oracleOptions.CommandTimeout(30);
            });
            
            // Configurações de desenvolvimento
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        });

        return services;
    }
}
