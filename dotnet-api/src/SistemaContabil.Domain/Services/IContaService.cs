using SistemaContabil.Domain.Entities;

namespace SistemaContabil.Domain.Services;

/// <summary>
/// Interface para serviços de Conta
/// </summary>
public interface IContaService
{
    /// <summary>
    /// Cria uma nova conta
    /// </summary>
    /// <param name="nome">Nome da conta</param>
    /// <param name="tipo">Tipo da conta (R ou D)</param>
    /// <returns>Conta criada</returns>
    /// <exception cref="ArgumentException">Lançada quando dados são inválidos</exception>
    Task<Conta> CriarAsync(string nome, char tipo);

    /// <summary>
    /// Atualiza uma conta existente
    /// </summary>
    /// <param name="id">ID da conta</param>
    /// <param name="nome">Novo nome</param>
    /// <param name="tipo">Novo tipo</param>
    /// <returns>Conta atualizada</returns>
    /// <exception cref="ArgumentException">Lançada quando dados são inválidos</exception>
    /// <exception cref="InvalidOperationException">Lançada quando conta não é encontrada</exception>
    Task<Conta> AtualizarAsync(int id, string nome, char tipo);

    /// <summary>
    /// Remove uma conta
    /// </summary>
    /// <param name="id">ID da conta</param>
    /// <returns>True se removida com sucesso</returns>
    /// <exception cref="InvalidOperationException">Lançada quando conta não pode ser removida</exception>
    Task<bool> RemoverAsync(int id);

    /// <summary>
    /// Obtém uma conta por ID
    /// </summary>
    /// <param name="id">ID da conta</param>
    /// <returns>Conta encontrada ou null</returns>
    Task<Conta?> ObterPorIdAsync(int id);

    /// <summary>
    /// Obtém todas as contas
    /// </summary>
    /// <returns>Lista de contas</returns>
    Task<IEnumerable<Conta>> ObterTodasAsync();

    /// <summary>
    /// Obtém contas por tipo
    /// </summary>
    /// <param name="tipo">Tipo da conta (R ou D)</param>
    /// <returns>Lista de contas do tipo especificado</returns>
    Task<IEnumerable<Conta>> ObterPorTipoAsync(char tipo);

    /// <summary>
    /// Busca contas por nome
    /// </summary>
    /// <param name="nome">Nome para busca</param>
    /// <returns>Lista de contas encontradas</returns>
    Task<IEnumerable<Conta>> BuscarPorNomeAsync(string nome);

    /// <summary>
    /// Obtém contas de receita
    /// </summary>
    /// <returns>Lista de contas de receita</returns>
    Task<IEnumerable<Conta>> ObterContasReceitaAsync();

    /// <summary>
    /// Obtém contas de despesa
    /// </summary>
    /// <returns>Lista de contas de despesa</returns>
    Task<IEnumerable<Conta>> ObterContasDespesaAsync();

    /// <summary>
    /// Verifica se uma conta pode ser removida
    /// </summary>
    /// <param name="id">ID da conta</param>
    /// <returns>True se pode ser removida</returns>
    Task<bool> PodeSerRemovidaAsync(int id);

    /// <summary>
    /// Obtém contas com registros contábeis
    /// </summary>
    /// <returns>Lista de contas com registros</returns>
    Task<IEnumerable<Conta>> ObterComRegistrosAsync();
}
