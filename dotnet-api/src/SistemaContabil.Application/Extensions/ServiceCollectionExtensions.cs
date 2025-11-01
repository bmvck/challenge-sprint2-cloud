using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SistemaContabil.Application.Mappings;
using SistemaContabil.Application.Services;
using SistemaContabil.Application.Validators;

namespace SistemaContabil.Application.Extensions;

/// <summary>
/// Extensões para configuração de serviços da camada de aplicação
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adiciona serviços da camada de aplicação
    /// </summary>
    /// <param name="services">Coleção de serviços</param>
    /// <returns>Coleção de serviços configurada</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Configuração do AutoMapper
        services.AddAutoMapper(typeof(MappingProfile));

        // Configuração do FluentValidation
        services.AddValidatorsFromAssemblyContaining<CentroCustoValidator>();

        // Registro dos serviços de aplicação
        services.AddScoped<ICentroCustoAppService, CentroCustoAppService>();
        services.AddScoped<IContaAppService, ContaAppService>();
        services.AddScoped<IRegistroContabilAppService, RegistroContabilAppService>();

        return services;
    }
}
