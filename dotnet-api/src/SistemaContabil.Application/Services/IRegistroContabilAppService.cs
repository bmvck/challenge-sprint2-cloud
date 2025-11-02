using SistemaContabil.Application.DTOs;

namespace SistemaContabil.Application.Services;

/// <summary>
/// Interface para serviços de aplicação de Registro Contábil
/// </summary>
public interface IRegistroContabilAppService
{
    /// <summary>
    /// Cria um novo registro contábil
    /// </summary>
    /// <param name="dto">DTO com dados do registro</param>
    /// <returns>Registro contábil criado</returns>
    Task<RegistroContabilDto> CriarAsync(CriarRegistroContabilDto dto);

    /// <summary>
    /// Atualiza um registro contábil existente
    /// </summary>
    /// <param name="id">ID do registro</param>
    /// <param name="dto">DTO com dados atualizados</param>
    /// <returns>Registro contábil atualizado</returns>
    Task<RegistroContabilDto> AtualizarAsync(int id, AtualizarRegistroContabilDto dto);

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
    Task<RegistroContabilDto?> ObterPorIdAsync(int id);

    /// <summary>
    /// Obtém todos os registros contábeis
    /// </summary>
    /// <returns>Lista de registros contábeis</returns>
    Task<IEnumerable<RegistroContabilDto>> ObterTodosAsync();

    /// <summary>
    /// Obtém registros contábeis por conta
    /// </summary>
    /// <param name="contaId">ID da conta</param>
    /// <returns>Lista de registros da conta</returns>
    Task<IEnumerable<RegistroContabilDto>> ObterPorContaAsync(int contaId);

    /// <summary>
    /// Obtém registros contábeis por centro de custo
    /// </summary>
    /// <param name="centroCustoId">ID do centro de custo</param>
    /// <returns>Lista de registros do centro de custo</returns>
    Task<IEnumerable<RegistroContabilDto>> ObterPorCentroCustoAsync(int centroCustoId);

    /// <summary>
    /// Obtém registros contábeis por período
    /// </summary>
    /// <param name="dataInicio">Data de início</param>
    /// <param name="dataFim">Data de fim</param>
    /// <returns>Lista de registros no período</returns>
    Task<IEnumerable<RegistroContabilDto>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);

    /// <summary>
    /// Obtém registros contábeis por valor
    /// </summary>
    /// <param name="valorMinimo">Valor mínimo</param>
    /// <param name="valorMaximo">Valor máximo</param>
    /// <returns>Lista de registros no intervalo de valores</returns>
    Task<IEnumerable<RegistroContabilDto>> ObterPorValorAsync(decimal valorMinimo, decimal valorMaximo);

    /// <summary>
    /// Obtém registros contábeis com filtros
    /// </summary>
    /// <param name="filtro">Filtros de busca</param>
    /// <returns>Lista de registros filtrados</returns>
    Task<IEnumerable<RegistroContabilDto>> ObterComFiltrosAsync(FiltroRegistroContabilDto filtro);

    /// <summary>
    /// Obtém registro contábil com detalhes
    /// </summary>
    /// <param name="id">ID do registro</param>
    /// <returns>Registro com detalhes ou null</returns>
    Task<RegistroContabilDetalhesDto?> ObterDetalhesAsync(int id);

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
    /// Busca paginada de registros contábeis
    /// </summary>
    Task<PagedResultDto<RegistroContabilDto>> SearchAsync(FiltroRegistroContabilDto filtro);
}
