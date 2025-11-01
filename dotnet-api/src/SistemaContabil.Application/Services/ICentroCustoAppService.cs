using SistemaContabil.Application.DTOs;

namespace SistemaContabil.Application.Services;

/// <summary>
/// Interface para serviços de aplicação de Centro de Custo
/// </summary>
public interface ICentroCustoAppService
{
    /// <summary>
    /// Cria um novo centro de custo
    /// </summary>
    /// <param name="dto">DTO com dados do centro de custo</param>
    /// <returns>Centro de custo criado</returns>
    Task<CentroCustoDto> CriarAsync(CriarCentroCustoDto dto);

    /// <summary>
    /// Atualiza um centro de custo existente
    /// </summary>
    /// <param name="id">ID do centro de custo</param>
    /// <param name="dto">DTO com dados atualizados</param>
    /// <returns>Centro de custo atualizado</returns>
    Task<CentroCustoDto> AtualizarAsync(int id, AtualizarCentroCustoDto dto);

    /// <summary>
    /// Remove um centro de custo
    /// </summary>
    /// <param name="id">ID do centro de custo</param>
    /// <returns>True se removido com sucesso</returns>
    Task<bool> RemoverAsync(int id);

    /// <summary>
    /// Obtém um centro de custo por ID
    /// </summary>
    /// <param name="id">ID do centro de custo</param>
    /// <returns>Centro de custo encontrado ou null</returns>
    Task<CentroCustoDto?> ObterPorIdAsync(int id);

    /// <summary>
    /// Obtém todos os centros de custo
    /// </summary>
    /// <returns>Lista de centros de custo</returns>
    Task<IEnumerable<CentroCustoDto>> ObterTodosAsync();

    /// <summary>
    /// Busca centros de custo por nome
    /// </summary>
    /// <param name="nome">Nome para busca</param>
    /// <returns>Lista de centros de custo encontrados</returns>
    Task<IEnumerable<CentroCustoDto>> BuscarPorNomeAsync(string nome);

    /// <summary>
    /// Obtém centro de custo com detalhes (incluindo registros)
    /// </summary>
    /// <param name="id">ID do centro de custo</param>
    /// <returns>Centro de custo com detalhes ou null</returns>
    Task<CentroCustoDetalhesDto?> ObterDetalhesAsync(int id);

    /// <summary>
    /// Obtém centros de custo com registros contábeis
    /// </summary>
    /// <returns>Lista de centros de custo com registros</returns>
    Task<IEnumerable<CentroCustoDto>> ObterComRegistrosAsync();

    /// <summary>
    /// Verifica se um centro de custo pode ser removido
    /// </summary>
    /// <param name="id">ID do centro de custo</param>
    /// <returns>True se pode ser removido</returns>
    Task<bool> PodeSerRemovidoAsync(int id);
}
