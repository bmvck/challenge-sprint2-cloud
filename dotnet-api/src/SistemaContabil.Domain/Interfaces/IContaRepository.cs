using SistemaContabil.Domain.Entities;

namespace SistemaContabil.Domain.Interfaces;

/// <summary>
/// Interface específica para repositório de Conta
/// </summary>
public interface IContaRepository : IRepository<Conta>
{
    /// <summary>
    /// Obtém conta por nome
    /// </summary>
    /// <param name="nome">Nome da conta</param>
    /// <returns>Conta encontrada ou null</returns>
    Task<Conta?> GetByNomeAsync(string nome);

    /// <summary>
    /// Verifica se existe conta com o nome especificado
    /// </summary>
    /// <param name="nome">Nome da conta</param>
    /// <param name="excludeId">ID a ser excluído da verificação (para atualizações)</param>
    /// <returns>True se existe, False caso contrário</returns>
    Task<bool> ExistsByNomeAsync(string nome, int? excludeId = null);

    /// <summary>
    /// Obtém contas por tipo
    /// </summary>
    /// <param name="tipo">Tipo da conta (D ou C)</param>
    /// <returns>Lista de contas do tipo especificado</returns>
    Task<IEnumerable<Conta>> GetByTipoAsync(char tipo);

    /// <summary>
    /// Obtém contas que contêm o texto especificado no nome
    /// </summary>
    /// <param name="texto">Texto para busca</param>
    /// <returns>Lista de contas encontradas</returns>
    Task<IEnumerable<Conta>> SearchByNomeAsync(string texto);

    /// <summary>
    /// Obtém contas com registros contábeis
    /// </summary>
    /// <returns>Lista de contas que possuem registros</returns>
    Task<IEnumerable<Conta>> GetWithRegistrosAsync();

    /// <summary>
    /// Obtém conta com seus registros contábeis
    /// </summary>
    /// <param name="id">ID da conta</param>
    /// <returns>Conta com registros ou null</returns>
    Task<Conta?> GetWithRegistrosAsync(int id);

    /// <summary>
    /// Obtém contas de débito
    /// </summary>
    /// <returns>Lista de contas de débito</returns>
    Task<IEnumerable<Conta>> GetContasDebitoAsync();

    /// <summary>
    /// Obtém contas de crédito
    /// </summary>
    /// <returns>Lista de contas de crédito</returns>
    Task<IEnumerable<Conta>> GetContasCreditoAsync();

    // Métodos adicionais para compatibilidade com serviços de domínio
    Task<Conta?> ObterPorIdAsync(int id);
    Task<IEnumerable<Conta>> ObterTodosAsync();
    Task<IEnumerable<Conta>> BuscarPorNomeAsync(string nome);
    Task<Conta> AdicionarAsync(Conta entity);
    Task<Conta> AtualizarAsync(Conta entity);
    Task<bool> RemoverAsync(int id);
    Task<IEnumerable<Conta>> ObterPorTipoAsync(char tipo);
    Task<IEnumerable<Conta>> ObterContasDebitoAsync();
    Task<IEnumerable<Conta>> ObterContasCreditoAsync();
    Task<IEnumerable<Conta>> ObterComRegistrosAsync();
}
