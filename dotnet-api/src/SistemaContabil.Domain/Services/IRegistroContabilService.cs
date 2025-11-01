using SistemaContabil.Domain.Entities;

namespace SistemaContabil.Domain.Services;

/// <summary>
/// Interface para serviços de Registro Contábil
/// </summary>
public interface IRegistroContabilService
{
    /// <summary>
    /// Cria um novo registro contábil
    /// </summary>
    /// <param name="valor">Valor do registro</param>
    /// <param name="contaId">ID da conta</param>
    /// <param name="centroCustoId">ID do centro de custo</param>
    /// <returns>Registro contábil criado</returns>
    /// <exception cref="ArgumentException">Lançada quando dados são inválidos</exception>
    Task<RegistroContabil> CriarAsync(decimal valor, int contaId, int centroCustoId);

    /// <summary>
    /// Atualiza um registro contábil existente
    /// </summary>
    /// <param name="id">ID do registro</param>
    /// <param name="valor">Novo valor</param>
    /// <param name="contaId">ID da conta</param>
    /// <param name="centroCustoId">ID do centro de custo</param>
    /// <returns>Registro contábil atualizado</returns>
    /// <exception cref="ArgumentException">Lançada quando dados são inválidos</exception>
    /// <exception cref="InvalidOperationException">Lançada quando registro não é encontrado</exception>
    Task<RegistroContabil> AtualizarAsync(int id, decimal valor, int contaId, int centroCustoId);

    /// <summary>
    /// Remove um registro contábil
    /// </summary>
    /// <param name="id">ID do registro</param>
    /// <returns>True se removido com sucesso</returns>
    Task<bool> RemoverAsync(int id);

    /// <summary>
    /// Obtém um registro contábil por ID
    /// </summary>
    /// <param name="id">ID do registro</param>
    /// <returns>Registro contábil encontrado ou null</returns>
    Task<RegistroContabil?> ObterPorIdAsync(int id);

    /// <summary>
    /// Obtém todos os registros contábeis
    /// </summary>
    /// <returns>Lista de registros contábeis</returns>
    Task<IEnumerable<RegistroContabil>> ObterTodosAsync();

    /// <summary>
    /// Obtém registros contábeis por conta
    /// </summary>
    /// <param name="contaId">ID da conta</param>
    /// <returns>Lista de registros da conta</returns>
    Task<IEnumerable<RegistroContabil>> ObterPorContaAsync(int contaId);

    /// <summary>
    /// Obtém registros contábeis por centro de custo
    /// </summary>
    /// <param name="centroCustoId">ID do centro de custo</param>
    /// <returns>Lista de registros do centro de custo</returns>
    Task<IEnumerable<RegistroContabil>> ObterPorCentroCustoAsync(int centroCustoId);

    /// <summary>
    /// Obtém registros contábeis por período
    /// </summary>
    /// <param name="dataInicio">Data de início</param>
    /// <param name="dataFim">Data de fim</param>
    /// <returns>Lista de registros no período</returns>
    Task<IEnumerable<RegistroContabil>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);

    /// <summary>
    /// Obtém registros contábeis por valor
    /// </summary>
    /// <param name="valorMinimo">Valor mínimo</param>
    /// <param name="valorMaximo">Valor máximo</param>
    /// <returns>Lista de registros no intervalo de valores</returns>
    Task<IEnumerable<RegistroContabil>> ObterPorValorAsync(decimal valorMinimo, decimal valorMaximo);

    /// <summary>
    /// Calcula o total de registros por conta
    /// </summary>
    /// <param name="contaId">ID da conta</param>
    /// <returns>Valor total dos registros da conta</returns>
    Task<decimal> CalcularTotalPorContaAsync(int contaId);

    /// <summary>
    /// Calcula o total de registros por centro de custo
    /// </summary>
    /// <param name="centroCustoId">ID do centro de custo</param>
    /// <returns>Valor total dos registros do centro de custo</returns>
    Task<decimal> CalcularTotalPorCentroCustoAsync(int centroCustoId);

    /// <summary>
    /// Calcula o total de registros por período
    /// </summary>
    /// <param name="dataInicio">Data de início</param>
    /// <param name="dataFim">Data de fim</param>
    /// <returns>Valor total dos registros no período</returns>
    Task<decimal> CalcularTotalPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);

    /// <summary>
    /// Obtém registros contábeis com informações das entidades relacionadas
    /// </summary>
    /// <returns>Lista de registros com conta e centro de custo</returns>
    Task<IEnumerable<RegistroContabil>> ObterComDetalhesAsync();

    /// <summary>
    /// Obtém registro contábil com informações das entidades relacionadas
    /// </summary>
    /// <param name="id">ID do registro</param>
    /// <returns>Registro com conta e centro de custo ou null</returns>
    Task<RegistroContabil?> ObterComDetalhesAsync(int id);
}
