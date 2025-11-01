using AutoMapper;
using SistemaContabil.Application.DTOs;
using SistemaContabil.Domain.Entities;

namespace SistemaContabil.Application.Mappings;

/// <summary>
/// Perfil de mapeamento do AutoMapper
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeamentos para CentroCusto
        CreateMap<CentroCusto, CentroCustoDto>()
            .ForMember(dest => dest.QuantidadeRegistros, opt => opt.MapFrom(src => src.RegistrosContabeis.Count))
            .ForMember(dest => dest.DataCriacao, opt => opt.Ignore());

        CreateMap<CentroCusto, CentroCustoDetalhesDto>()
            .ForMember(dest => dest.RegistrosContabeis, opt => opt.MapFrom(src => src.RegistrosContabeis))
            .ForMember(dest => dest.TotalRegistros, opt => opt.MapFrom(src => src.RegistrosContabeis.Count))
            .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.RegistrosContabeis.Sum(r => r.Valor)));

        CreateMap<CriarCentroCustoDto, CentroCusto>()
            .ForMember(dest => dest.IdCentroCusto, opt => opt.Ignore())
            .ForMember(dest => dest.RegistrosContabeis, opt => opt.Ignore());

        CreateMap<AtualizarCentroCustoDto, CentroCusto>()
            .ForMember(dest => dest.IdCentroCusto, opt => opt.Ignore())
            .ForMember(dest => dest.RegistrosContabeis, opt => opt.Ignore());

        // Mapeamentos para Conta
        CreateMap<Conta, ContaDto>()
            .ForMember(dest => dest.TipoDescricao, opt => opt.MapFrom(src => src.GetTipoDescricao()))
            .ForMember(dest => dest.QuantidadeRegistros, opt => opt.MapFrom(src => src.RegistrosContabeis.Count))
            .ForMember(dest => dest.DataCriacao, opt => opt.Ignore());

        CreateMap<Conta, ContaDetalhesDto>()
            .ForMember(dest => dest.TipoDescricao, opt => opt.MapFrom(src => src.GetTipoDescricao()))
            .ForMember(dest => dest.RegistrosContabeis, opt => opt.MapFrom(src => src.RegistrosContabeis))
            .ForMember(dest => dest.TotalRegistros, opt => opt.MapFrom(src => src.RegistrosContabeis.Count))
            .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.RegistrosContabeis.Sum(r => r.Valor)));

        CreateMap<CriarContaDto, Conta>()
            .ForMember(dest => dest.IdConta, opt => opt.Ignore())
            .ForMember(dest => dest.RegistrosContabeis, opt => opt.Ignore());

        CreateMap<AtualizarContaDto, Conta>()
            .ForMember(dest => dest.IdConta, opt => opt.Ignore())
            .ForMember(dest => dest.RegistrosContabeis, opt => opt.Ignore());

        // Mapeamentos para RegistroContabil
        CreateMap<RegistroContabil, RegistroContabilDto>()
            .ForMember(dest => dest.NomeConta, opt => opt.MapFrom(src => src.Conta.NomeConta))
            .ForMember(dest => dest.NomeCentroCusto, opt => opt.MapFrom(src => src.CentroCusto.NomeCentroCusto));

        CreateMap<RegistroContabil, RegistroContabilDetalhesDto>()
            .ForMember(dest => dest.Conta, opt => opt.MapFrom(src => src.Conta))
            .ForMember(dest => dest.CentroCusto, opt => opt.MapFrom(src => src.CentroCusto));

        CreateMap<CriarRegistroContabilDto, RegistroContabil>()
            .ForMember(dest => dest.IdRegistroContabil, opt => opt.Ignore())
            .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
            .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
            .ForMember(dest => dest.Conta, opt => opt.Ignore())
            .ForMember(dest => dest.CentroCusto, opt => opt.Ignore());

        CreateMap<AtualizarRegistroContabilDto, RegistroContabil>()
            .ForMember(dest => dest.IdRegistroContabil, opt => opt.Ignore())
            .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
            .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
            .ForMember(dest => dest.Conta, opt => opt.Ignore())
            .ForMember(dest => dest.CentroCusto, opt => opt.Ignore());
    }
}
