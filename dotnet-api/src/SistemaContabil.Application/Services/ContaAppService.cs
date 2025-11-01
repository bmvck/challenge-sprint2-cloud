using AutoMapper;
using SistemaContabil.Application.DTOs;
using SistemaContabil.Domain.Interfaces;
using SistemaContabil.Domain.Services;

namespace SistemaContabil.Application.Services;

/// <summary>
/// Serviço de aplicação para Conta
/// </summary>
public class ContaAppService : IContaAppService
{
    private readonly IContaService _contaService;
    private readonly IMapper _mapper;

    public ContaAppService(IContaService contaService, IMapper mapper)
    {
        _contaService = contaService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ContaDto>> ObterTodosAsync()
    {
        var contas = await _contaService.ObterTodasAsync();
        return _mapper.Map<IEnumerable<ContaDto>>(contas);
    }

    public async Task<ContaDto?> ObterPorIdAsync(int id)
    {
        var conta = await _contaService.ObterPorIdAsync(id);
        return _mapper.Map<ContaDto?>(conta);
    }

    public async Task<ContaDetalhesDto?> ObterDetalhesAsync(int id)
    {
        var conta = await _contaService.ObterPorIdAsync(id);
        return _mapper.Map<ContaDetalhesDto?>(conta);
    }

    public async Task<IEnumerable<ContaDto>> BuscarPorNomeAsync(string nome)
    {
        var contas = await _contaService.BuscarPorNomeAsync(nome);
        return _mapper.Map<IEnumerable<ContaDto>>(contas);
    }

    public async Task<IEnumerable<ContaDto>> BuscarPorTipoAsync(char tipo)
    {
        var contas = await _contaService.ObterPorTipoAsync(tipo);
        return _mapper.Map<IEnumerable<ContaDto>>(contas);
    }

    public async Task<ContaDto> CriarAsync(CriarContaDto dto)
    {
        var conta = await _contaService.CriarAsync(dto.NomeConta, dto.Tipo);
        return _mapper.Map<ContaDto>(conta);
    }

    public async Task<ContaDto> AtualizarAsync(int id, AtualizarContaDto dto)
    {
        var conta = await _contaService.AtualizarAsync(id, dto.NomeConta, dto.Tipo);
        return _mapper.Map<ContaDto>(conta);
    }

    public async Task<bool> RemoverAsync(int id)
    {
        return await _contaService.RemoverAsync(id);
    }

    public async Task<bool> PodeSerRemovidaAsync(int id)
    {
        return await _contaService.PodeSerRemovidaAsync(id);
    }

    public async Task<IEnumerable<ContaDto>> ObterTodasAsync()
    {
        var contas = await _contaService.ObterTodasAsync();
        return _mapper.Map<IEnumerable<ContaDto>>(contas);
    }

    public async Task<IEnumerable<ContaDto>> ObterPorTipoAsync(char tipo)
    {
        var contas = await _contaService.ObterPorTipoAsync(tipo);
        return _mapper.Map<IEnumerable<ContaDto>>(contas);
    }

    public async Task<IEnumerable<ContaDto>> ObterContasDebitoAsync()
    {
        var contas = await _contaService.ObterContasDebitoAsync();
        return _mapper.Map<IEnumerable<ContaDto>>(contas);
    }

    public async Task<IEnumerable<ContaDto>> ObterContasCreditoAsync()
    {
        var contas = await _contaService.ObterContasCreditoAsync();
        return _mapper.Map<IEnumerable<ContaDto>>(contas);
    }

    public async Task<IEnumerable<ContaDto>> ObterComRegistrosAsync()
    {
        var contas = await _contaService.ObterComRegistrosAsync();
        return _mapper.Map<IEnumerable<ContaDto>>(contas);
    }
}
