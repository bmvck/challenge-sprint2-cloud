using AutoMapper;
using SistemaContabil.Application.DTOs;
using SistemaContabil.Domain.Interfaces;
using SistemaContabil.Domain.Services;

namespace SistemaContabil.Application.Services;

/// <summary>
/// Serviço de aplicação para Centro de Custo
/// </summary>
public class CentroCustoAppService : ICentroCustoAppService
{
    private readonly ICentroCustoService _centroCustoService;
    private readonly IMapper _mapper;

    public CentroCustoAppService(ICentroCustoService centroCustoService, IMapper mapper)
    {
        _centroCustoService = centroCustoService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CentroCustoDto>> ObterTodosAsync()
    {
        var centrosCusto = await _centroCustoService.ObterTodosAsync();
        return _mapper.Map<IEnumerable<CentroCustoDto>>(centrosCusto);
    }

    public async Task<CentroCustoDto?> ObterPorIdAsync(int id)
    {
        var centroCusto = await _centroCustoService.ObterPorIdAsync(id);
        return _mapper.Map<CentroCustoDto?>(centroCusto);
    }

    public async Task<CentroCustoDetalhesDto?> ObterDetalhesAsync(int id)
    {
        var centroCusto = await _centroCustoService.ObterPorIdAsync(id);
        return _mapper.Map<CentroCustoDetalhesDto?>(centroCusto);
    }

    public async Task<IEnumerable<CentroCustoDto>> BuscarPorNomeAsync(string nome)
    {
        var centrosCusto = await _centroCustoService.BuscarPorNomeAsync(nome);
        return _mapper.Map<IEnumerable<CentroCustoDto>>(centrosCusto);
    }

    public async Task<CentroCustoDto> CriarAsync(CriarCentroCustoDto dto)
    {
        var centroCusto = await _centroCustoService.CriarAsync(dto.NomeCentroCusto);
        return _mapper.Map<CentroCustoDto>(centroCusto);
    }

    public async Task<CentroCustoDto> AtualizarAsync(int id, AtualizarCentroCustoDto dto)
    {
        var centroCusto = await _centroCustoService.AtualizarAsync(id, dto.NomeCentroCusto);
        return _mapper.Map<CentroCustoDto>(centroCusto);
    }

    public async Task<bool> RemoverAsync(int id)
    {
        return await _centroCustoService.RemoverAsync(id);
    }

    public async Task<bool> PodeSerRemovidoAsync(int id)
    {
        return await _centroCustoService.PodeSerRemovidoAsync(id);
    }

    public async Task<IEnumerable<CentroCustoDto>> ObterComRegistrosAsync()
    {
        var centrosCusto = await _centroCustoService.ObterComRegistrosAsync();
        return _mapper.Map<IEnumerable<CentroCustoDto>>(centrosCusto);
    }
}
