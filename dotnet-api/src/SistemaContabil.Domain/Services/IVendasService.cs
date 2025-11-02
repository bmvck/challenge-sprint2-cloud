using SistemaContabil.Domain.Entities;

namespace SistemaContabil.Domain.Services;

/// <summary>
/// Interface para serviços de Vendas
/// </summary>
public interface IVendasService
{
    /// <summary>
    /// Cria uma nova venda
    /// </summary>
    Task<Vendas> CriarAsync(int clienteId, int regContId, long? vendaEventoId = null);

    /// <summary>
    /// Atualiza uma venda existente
    /// </summary>
    Task<Vendas> AtualizarAsync(int id, int clienteId, int regContId, long? vendaEventoId = null);

    /// <summary>
    /// Remove uma venda
    /// </summary>
    Task<bool> RemoverAsync(int id);

    /// <summary>
    /// Obtém venda por ID
    /// </summary>
    Task<Vendas?> ObterPorIdAsync(int id);

    /// <summary>
    /// Obtém todas as vendas
    /// </summary>
    Task<IEnumerable<Vendas>> ObterTodasAsync();

    /// <summary>
    /// Obtém vendas por cliente
    /// </summary>
    Task<IEnumerable<Vendas>> ObterPorClienteAsync(int clienteId);

    /// <summary>
    /// Obtém vendas por registro contábil
    /// </summary>
    Task<IEnumerable<Vendas>> ObterPorRegContAsync(int regContId);
}
