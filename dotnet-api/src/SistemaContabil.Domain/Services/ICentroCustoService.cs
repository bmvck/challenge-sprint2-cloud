using SistemaContabil.Domain.Entities;

namespace SistemaContabil.Domain.Services;

/// <summary>
/// Interface para serviços de Centro de Custo
/// </summary>
public interface ICentroCustoService
{
    /// <summary>
    /// Cria um novo centro de custo
    /// </summary>
    /// <param name="nome">Nome do centro de custo</param>
    /// <returns>Centro de custo criado</returns>
    /// <exception cref="ArgumentException">Lançada quando o nome é inválido</exception>
    Task<CentroCusto> CriarAsync(string nome);

    /// <summary>
    /// Atualiza um centro de custo existente
    /// </summary>
    /// <param name="id">ID do centro de custo</param>
    /// <param name="nome">Novo nome</param>
    /// <returns>Centro de custo atualizado</returns>
    /// <exception cref="ArgumentException">Lançada quando dados são inválidos</exception>
    /// <exception cref="InvalidOperationException">Lançada quando centro de custo não é encontrado</exception>
    Task<CentroCusto> AtualizarAsync(int id, string nome);

    /// <summary>
    /// Remove um centro de custo
    /// </summary>
    /// <param name="id">ID do centro de custo</param>
    /// <returns>True se removido com sucesso</returns>
    /// <exception cref="InvalidOperationException">Lançada quando centro de custo não pode ser removido</exception>
    Task<bool> RemoverAsync(int id);

    /// <summary>
    /// Obtém um centro de custo por ID
    /// </summary>
    /// <param name="id">ID do centro de custo</param>
    /// <returns>Centro de custo encontrado ou null</returns>
    Task<CentroCusto?> ObterPorIdAsync(int id);

    /// <summary>
    /// Obtém todos os centros de custo
    /// </summary>
    /// <returns>Lista de centros de custo</returns>
    Task<IEnumerable<CentroCusto>> ObterTodosAsync();

    /// <summary>
    /// Busca centros de custo por nome
    /// </summary>
    /// <param name="nome">Nome para busca</param>
    /// <returns>Lista de centros de custo encontrados</returns>
    Task<IEnumerable<CentroCusto>> BuscarPorNomeAsync(string nome);

    /// <summary>
    /// Verifica se um centro de custo pode ser removido
    /// </summary>
    /// <param name="id">ID do centro de custo</param>
    /// <returns>True se pode ser removido</returns>
    Task<bool> PodeSerRemovidoAsync(int id);

    /// <summary>
    /// Obtém centros de custo com registros contábeis
    /// </summary>
    /// <returns>Lista de centros de custo com registros</returns>
    Task<IEnumerable<CentroCusto>> ObterComRegistrosAsync();
}
