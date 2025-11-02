using SistemaContabil.Application.DTOs;

namespace SistemaContabil.Application.Services;

/// <summary>
/// Interface para serviço de aplicação de Cliente
/// </summary>
public interface IClienteAppService
{
    /// <summary>
    /// Obtém todos os clientes
    /// </summary>
    Task<IEnumerable<ClienteDto>> ObterTodosAsync();

    /// <summary>
    /// Obtém cliente por ID
    /// </summary>
    Task<ClienteDto?> ObterPorIdAsync(int id);

    /// <summary>
    /// Cria um novo cliente
    /// </summary>
    Task<ClienteDto> CriarAsync(CriarClienteDto dto);

    /// <summary>
    /// Atualiza um cliente existente
    /// </summary>
    Task<ClienteDto> AtualizarAsync(int id, AtualizarClienteDto dto);

    /// <summary>
    /// Remove um cliente
    /// </summary>
    Task<bool> RemoverAsync(int id);

    /// <summary>
    /// Busca paginada de clientes
    /// </summary>
    Task<PagedResultDto<ClienteDto>> SearchAsync(FiltroClienteDto filtro);
}
