using SistemaContabil.Domain.Entities;

namespace SistemaContabil.Domain.Interfaces;

/// <summary>
/// Interface específica para repositório de Vendas
/// </summary>
public interface IVendasRepository : IRepository<Vendas>
{
    /// <summary>
    /// Obtém vendas por cliente
    /// </summary>
    Task<IEnumerable<Vendas>> GetByClienteIdAsync(int clienteId);

    /// <summary>
    /// Obtém vendas por registro contábil
    /// </summary>
    Task<IEnumerable<Vendas>> GetByRegContIdAsync(int regContId);

    /// <summary>
    /// Busca paginada de vendas com filtros
    /// </summary>
    Task<(IEnumerable<Vendas> Items, int TotalCount)> SearchPagedAsync(
        int? clienteId = null,
        int? regContId = null,
        long? vendaEventoId = null,
        int page = 1,
        int pageSize = 10,
        string? sortBy = null,
        bool isDescending = false);

    // Métodos de compatibilidade
    Task<Vendas?> ObterPorIdAsync(int id);
    Task<IEnumerable<Vendas>> ObterTodosAsync();
    Task<Vendas> AdicionarAsync(Vendas entity);
    Task<Vendas> AtualizarAsync(Vendas entity);
    Task<bool> RemoverAsync(int id);
}
