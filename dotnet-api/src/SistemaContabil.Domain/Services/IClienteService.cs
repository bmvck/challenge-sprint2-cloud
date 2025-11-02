using SistemaContabil.Domain.Entities;

namespace SistemaContabil.Domain.Services;

/// <summary>
/// Interface para serviços de Cliente
/// </summary>
public interface IClienteService
{
    /// <summary>
    /// Cria um novo cliente
    /// </summary>
    Task<Cliente> CriarAsync(string nome, string cpfCnpj, string email, string senha, char ativo = 'S');

    /// <summary>
    /// Atualiza um cliente existente
    /// </summary>
    Task<Cliente> AtualizarAsync(int id, string nome, string email, char ativo);

    /// <summary>
    /// Remove um cliente
    /// </summary>
    Task<bool> RemoverAsync(int id);

    /// <summary>
    /// Obtém cliente por ID
    /// </summary>
    Task<Cliente?> ObterPorIdAsync(int id);

    /// <summary>
    /// Obtém todos os clientes
    /// </summary>
    Task<IEnumerable<Cliente>> ObterTodosAsync();

    /// <summary>
    /// Busca clientes por nome
    /// </summary>
    Task<IEnumerable<Cliente>> BuscarPorNomeAsync(string nome);

    /// <summary>
    /// Obtém cliente por CPF/CNPJ
    /// </summary>
    Task<Cliente?> ObterPorCpfCnpjAsync(string cpfCnpj);

    /// <summary>
    /// Obtém cliente por email
    /// </summary>
    Task<Cliente?> ObterPorEmailAsync(string email);
}
