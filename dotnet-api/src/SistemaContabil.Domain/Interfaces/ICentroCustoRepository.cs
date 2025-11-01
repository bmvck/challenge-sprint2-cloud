using SistemaContabil.Domain.Entities;

namespace SistemaContabil.Domain.Interfaces;

/// <summary>
/// Interface específica para repositório de Centro de Custo
/// </summary>
public interface ICentroCustoRepository : IRepository<CentroCusto>
{
    /// <summary>
    /// Obtém centro de custo por nome
    /// </summary>
    /// <param name="nome">Nome do centro de custo</param>
    /// <returns>Centro de custo encontrado ou null</returns>
    Task<CentroCusto?> GetByNomeAsync(string nome);

    /// <summary>
    /// Verifica se existe centro de custo com o nome especificado
    /// </summary>
    /// <param name="nome">Nome do centro de custo</param>
    /// <param name="excludeId">ID a ser excluído da verificação (para atualizações)</param>
    /// <returns>True se existe, False caso contrário</returns>
    Task<bool> ExistsByNomeAsync(string nome, int? excludeId = null);

    /// <summary>
    /// Obtém centros de custo que contêm o texto especificado no nome
    /// </summary>
    /// <param name="texto">Texto para busca</param>
    /// <returns>Lista de centros de custo encontrados</returns>
    Task<IEnumerable<CentroCusto>> SearchByNomeAsync(string texto);

    /// <summary>
    /// Obtém centros de custo com registros contábeis
    /// </summary>
    /// <returns>Lista de centros de custo que possuem registros</returns>
    Task<IEnumerable<CentroCusto>> GetWithRegistrosAsync();

    /// <summary>
    /// Obtém centro de custo com seus registros contábeis
    /// </summary>
    /// <param name="id">ID do centro de custo</param>
    /// <returns>Centro de custo com registros ou null</returns>
    Task<CentroCusto?> GetWithRegistrosAsync(int id);

    // Métodos adicionais para compatibilidade com serviços de domínio
    Task<CentroCusto?> ObterPorIdAsync(int id);
    Task<IEnumerable<CentroCusto>> ObterTodosAsync();
    Task<IEnumerable<CentroCusto>> BuscarPorNomeAsync(string nome);
    Task<CentroCusto> AdicionarAsync(CentroCusto entity);
    Task<CentroCusto> AtualizarAsync(CentroCusto entity);
    Task<bool> RemoverAsync(int id);
}
