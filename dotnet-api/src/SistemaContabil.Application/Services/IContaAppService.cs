using SistemaContabil.Application.DTOs;

namespace SistemaContabil.Application.Services;

/// <summary>
/// Interface para serviços de aplicação de Conta
/// </summary>
public interface IContaAppService
{
    /// <summary>
    /// Cria uma nova conta
    /// </summary>
    /// <param name="dto">DTO com dados da conta</param>
    /// <returns>Conta criada</returns>
    Task<ContaDto> CriarAsync(CriarContaDto dto);

    /// <summary>
    /// Atualiza uma conta existente
    /// </summary>
    /// <param name="id">ID da conta</param>
    /// <param name="dto">DTO com dados atualizados</param>
    /// <returns>Conta atualizada</returns>
    Task<ContaDto> AtualizarAsync(int id, AtualizarContaDto dto);

    /// <summary>
    /// Remove uma conta
    /// </summary>
    /// <param name="id">ID da conta</param>
    /// <returns>True se removida com sucesso</returns>
    Task<bool> RemoverAsync(int id);

    /// <summary>
    /// Obtém uma conta por ID
    /// </summary>
    /// <param name="id">ID da conta</param>
    /// <returns>Conta encontrada ou null</returns>
    Task<ContaDto?> ObterPorIdAsync(int id);

    /// <summary>
    /// Obtém todas as contas
    /// </summary>
    /// <returns>Lista de contas</returns>
    Task<IEnumerable<ContaDto>> ObterTodasAsync();

    /// <summary>
    /// Obtém contas por tipo
    /// </summary>
    /// <param name="tipo">Tipo da conta (D ou C)</param>
    /// <returns>Lista de contas do tipo especificado</returns>
    Task<IEnumerable<ContaDto>> ObterPorTipoAsync(char tipo);

    /// <summary>
    /// Busca contas por nome
    /// </summary>
    /// <param name="nome">Nome para busca</param>
    /// <returns>Lista de contas encontradas</returns>
    Task<IEnumerable<ContaDto>> BuscarPorNomeAsync(string nome);

    /// <summary>
    /// Obtém conta com detalhes (incluindo registros)
    /// </summary>
    /// <param name="id">ID da conta</param>
    /// <returns>Conta com detalhes ou null</returns>
    Task<ContaDetalhesDto?> ObterDetalhesAsync(int id);

    /// <summary>
    /// Obtém contas de débito
    /// </summary>
    /// <returns>Lista de contas de débito</returns>
    Task<IEnumerable<ContaDto>> ObterContasDebitoAsync();

    /// <summary>
    /// Obtém contas de crédito
    /// </summary>
    /// <returns>Lista de contas de crédito</returns>
    Task<IEnumerable<ContaDto>> ObterContasCreditoAsync();

    /// <summary>
    /// Obtém contas com registros contábeis
    /// </summary>
    /// <returns>Lista de contas com registros</returns>
    Task<IEnumerable<ContaDto>> ObterComRegistrosAsync();

    /// <summary>
    /// Verifica se uma conta pode ser removida
    /// </summary>
    /// <param name="id">ID da conta</param>
    /// <returns>True se pode ser removida</returns>
    Task<bool> PodeSerRemovidaAsync(int id);
}
