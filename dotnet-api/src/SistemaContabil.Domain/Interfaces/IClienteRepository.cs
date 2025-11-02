using SistemaContabil.Domain.Entities;

namespace SistemaContabil.Domain.Interfaces;

/// <summary>
/// Interface específica para repositório de Cliente
/// </summary>
public interface IClienteRepository : IRepository<Cliente>
{
    /// <summary>
    /// Obtém cliente por CPF/CNPJ
    /// </summary>
    Task<Cliente?> GetByCpfCnpjAsync(string cpfCnpj);

    /// <summary>
    /// Obtém cliente por email
    /// </summary>
    Task<Cliente?> GetByEmailAsync(string email);

    /// <summary>
    /// Verifica se existe cliente com o CPF/CNPJ especificado
    /// </summary>
    /// <param name="cpfCnpj">CPF ou CNPJ do cliente</param>
    /// <param name="excludeId">ID a ser excluído da verificação (para atualizações)</param>
    /// <returns>True se existe, False caso contrário</returns>
    Task<bool> ExistsByCpfCnpjAsync(string cpfCnpj, int? excludeId = null);

    /// <summary>
    /// Verifica se existe cliente com o email especificado
    /// </summary>
    /// <param name="email">Email do cliente</param>
    /// <param name="excludeId">ID a ser excluído da verificação (para atualizações)</param>
    /// <returns>True se existe, False caso contrário</returns>
    Task<bool> ExistsByEmailAsync(string email, int? excludeId = null);

    /// <summary>
    /// Busca clientes por nome (parcial)
    /// </summary>
    Task<IEnumerable<Cliente>> SearchByNomeAsync(string nome);

    /// <summary>
    /// Busca paginada de clientes com filtros
    /// </summary>
    Task<(IEnumerable<Cliente> Items, int TotalCount)> SearchPagedAsync(
        string? nome = null,
        string? cpfCnpj = null,
        char? ativo = null,
        string? email = null,
        int page = 1,
        int pageSize = 10,
        string? sortBy = null,
        bool isDescending = false);

    // Métodos de compatibilidade
    Task<Cliente?> ObterPorIdAsync(int id);
    Task<IEnumerable<Cliente>> ObterTodosAsync();
    Task<Cliente> AdicionarAsync(Cliente entity);
    Task<Cliente> AtualizarAsync(Cliente entity);
    Task<bool> RemoverAsync(int id);
}
