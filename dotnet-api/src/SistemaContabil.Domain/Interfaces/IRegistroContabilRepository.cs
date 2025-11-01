using SistemaContabil.Domain.Entities;

namespace SistemaContabil.Domain.Interfaces;

/// <summary>
/// Interface específica para repositório de Registro Contábil
/// </summary>
public interface IRegistroContabilRepository : IRepository<RegistroContabil>
{
    /// <summary>
    /// Obtém registros contábeis por conta
    /// </summary>
    /// <param name="contaId">ID da conta</param>
    /// <returns>Lista de registros da conta</returns>
    Task<IEnumerable<RegistroContabil>> GetByContaAsync(int contaId);

    /// <summary>
    /// Obtém registros contábeis por centro de custo
    /// </summary>
    /// <param name="centroCustoId">ID do centro de custo</param>
    /// <returns>Lista de registros do centro de custo</returns>
    Task<IEnumerable<RegistroContabil>> GetByCentroCustoAsync(int centroCustoId);

    /// <summary>
    /// Obtém registros contábeis por período
    /// </summary>
    /// <param name="dataInicio">Data de início</param>
    /// <param name="dataFim">Data de fim</param>
    /// <returns>Lista de registros no período</returns>
    Task<IEnumerable<RegistroContabil>> GetByPeriodoAsync(DateTime dataInicio, DateTime dataFim);

    /// <summary>
    /// Obtém registros contábeis por valor
    /// </summary>
    /// <param name="valorMinimo">Valor mínimo</param>
    /// <param name="valorMaximo">Valor máximo</param>
    /// <returns>Lista de registros no intervalo de valores</returns>
    Task<IEnumerable<RegistroContabil>> GetByValorAsync(decimal valorMinimo, decimal valorMaximo);

    /// <summary>
    /// Obtém registros contábeis com informações das entidades relacionadas
    /// </summary>
    /// <returns>Lista de registros com conta e centro de custo</returns>
    Task<IEnumerable<RegistroContabil>> GetWithDetailsAsync();

    /// <summary>
    /// Obtém registro contábil com informações das entidades relacionadas
    /// </summary>
    /// <param name="id">ID do registro</param>
    /// <returns>Registro com conta e centro de custo ou null</returns>
    Task<RegistroContabil?> GetWithDetailsAsync(int id);

    /// <summary>
    /// Calcula o total de registros por conta
    /// </summary>
    /// <param name="contaId">ID da conta</param>
    /// <returns>Valor total dos registros da conta</returns>
    Task<decimal> GetTotalByContaAsync(int contaId);

    /// <summary>
    /// Calcula o total de registros por centro de custo
    /// </summary>
    /// <param name="centroCustoId">ID do centro de custo</param>
    /// <returns>Valor total dos registros do centro de custo</returns>
    Task<decimal> GetTotalByCentroCustoAsync(int centroCustoId);

    /// <summary>
    /// Calcula o total de registros por período
    /// </summary>
    /// <param name="dataInicio">Data de início</param>
    /// <param name="dataFim">Data de fim</param>
    /// <returns>Valor total dos registros no período</returns>
    Task<decimal> GetTotalByPeriodoAsync(DateTime dataInicio, DateTime dataFim);

    /// <summary>
    /// Obtém registros contábeis ordenados por data de criação
    /// </summary>
    /// <param name="ascending">True para ordem crescente, False para decrescente</param>
    /// <returns>Lista de registros ordenados</returns>
    Task<IEnumerable<RegistroContabil>> GetOrderedByDataAsync(bool ascending = true);

    /// <summary>
    /// Obtém registros contábeis ordenados por valor
    /// </summary>
    /// <param name="ascending">True para ordem crescente, False para decrescente</param>
    /// <returns>Lista de registros ordenados</returns>
    Task<IEnumerable<RegistroContabil>> GetOrderedByValorAsync(bool ascending = true);

    // Métodos adicionais para compatibilidade com serviços de domínio
    Task<RegistroContabil?> ObterPorIdAsync(int id);
    Task<IEnumerable<RegistroContabil>> ObterTodosAsync();
    Task<RegistroContabil> AdicionarAsync(RegistroContabil entity);
    Task<RegistroContabil> AtualizarAsync(RegistroContabil entity);
    Task<bool> RemoverAsync(int id);
    Task<IEnumerable<RegistroContabil>> ObterPorContaAsync(int contaId);
    Task<IEnumerable<RegistroContabil>> ObterPorCentroCustoAsync(int centroCustoId);
    Task<IEnumerable<RegistroContabil>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
    Task<IEnumerable<RegistroContabil>> ObterPorValorAsync(decimal valorMinimo, decimal valorMaximo);
    Task<IEnumerable<RegistroContabil>> ObterComDetalhesAsync();
    Task<RegistroContabil?> ObterComDetalhesAsync(int id);
    Task<decimal> CalcularTotalPorContaAsync(int contaId);
    Task<decimal> CalcularTotalPorCentroCustoAsync(int centroCustoId);
    Task<decimal> CalcularTotalPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
}
